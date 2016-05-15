using System;
using System.ComponentModel;  //for background workers
using System.Diagnostics;     //for stopwatch timers
using System.IO;              //for file io
using System.Text;            //for string manipulation
using System.Windows.Forms;  
using System.Threading.Tasks; //for task parallel (not used yet)
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using System.Drawing;
namespace DAA_Project_core
{
    public partial class MainForm : Form 
    {
        /// <summary>
        /// field inits
        /// </summary>
        LogForm form;
        private string folderPath = string.Empty;
        private int windowSize=0;
        private string[] targetfiles;
        string matchedfile;
        string filetomatch;
        List<string> filetomatchwords = new List<string>();
        double threshold = 0.5;
        Stopwatch sw = new Stopwatch();
        int targetFilesLength = 0;
        BlockingCollection<FileObject> BC2;
        List<string[]> hugeList = new List<string[]>();
        AboutForm about;
     
        public MainForm()
        {
            InitializeComponent();
            form = new LogForm(this);
            about = new AboutForm();
            //increase process priority may lead to faster execution as the prog will have more time inside cpu
            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
        }

        /// <summary>
        /// opens the folder browser dialog and gets the path in text of the selected folder  if no path is selected
        /// it returns an empty string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            FolderPathTextbox.Text = OpenFolder();
            folderPath = FolderPathTextbox.Text;
            targetfiles = GetFileCollection(folderPath);
            if (targetfiles != null)
            {
                if(targetfiles.Length!=0)
                LogBox.AppendText(String.Format("Loaded {0} File Entries\n", targetfiles.Length));
            }
        }

        /// <summary>
        ///  every thing begins here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  async void ExecuteButton_Click(object sender, EventArgs e)
        {
            
            //get window size and then go through checks
            windowSize = Convert.ToInt32(WindowsSizeSpinner.Value);
            if (folderPath == string.Empty)
            {
                LogBox.AppendText("Please select a valid folder in order to continue !" + Environment.NewLine);
            }
            else  if (windowSize==0)
            {
                LogBox.AppendText("Window size must be greater than 0 !" + Environment.NewLine);
            }
            else if(filetomatchwords.Count==0)
            {
                LogBox.AppendText("Please select a target file and wait for it to load !" + Environment.NewLine);
            }
            else
            {
                sw.Start();
                targetFilesLength = targetfiles.Length;
                //size of bocking collection is preset to avoid resizing the internal array
                BC2 = new BlockingCollection<FileObject>(targetFilesLength);
                //int x = await processing_thread(windowSize, targetfiles, progressIndicator2);
                //text =  await generating_unified_task();  //done fucking shit
                //LogBox.AppendText(text);
                //LogBox.AppendText(sw.Elapsed.ToString());
                //do everything in seprate thread from ui
                var task_1 = Task.Factory.StartNew(() =>
                 {
                     //all the calculations happen here
                     t1();

                 });

                //according to stackoverflow finally blocks do not work in background threads 
                //since all task factory threads are placed in the threadpool and the threadpool handles
                //background threads there is no finally block here any disposal must happen inside catch or try block
                var task_2 = Task.Factory.StartNew(() =>
                {

                    t2();

                });

            }
        }

        #region consumer-producer wala code



        /// <summary>
        /// adds fileobjects to the blocking collection
        /// </summary>
        private void t1()
        {
            

            var splitter = new StringSplitter(4000);
            
            StringBuilder builder =new StringBuilder();
            try
            {


                this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("started task 1\n")); });

               
                foreach (var file in targetfiles)
                {
                    foreach (string line in File.ReadLines(file))
                    {
                        builder.Append(line);
                    }
                    BC2.Add(new FileObject(file,builder.ToString()));
                    builder.Clear();
                   
                }
                 BC2.CompleteAdding(); //tells the blocking collection that it should not expect any more data to be added to it
                //this ensures that the collection does not sit in an infinite blocking state

            }
            catch (Exception xx)
            {

               
                
            }
            finally
            {
                this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("Finally Block Reached in task 1\n")); });
            }
        }


        private void t2()
        {
            int count = 1;
            try
            {

                this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("started task 2\n")); });
                var splitter = new StringSplitter(10000);
                foreach (var x in  BC2.GetConsumingEnumerable())
                {

                    
                    splitter.SafeSplit(x.FileContentstring, ' ');
                    x.FileContentstring = string.Empty;
                    if (((double)filetomatchwords.Intersect(splitter.Results).Count() / (double)filetomatchwords.Union(splitter.Results).Count()) > threshold)
                    {
                        matchedfile = x.FileName;
                    }
                    Array.Clear(splitter.buffer, 0, splitter.buffer.Length);
                    this.Invoke((MethodInvoker)delegate { FilesLeft.Text = targetFilesLength + "/" + count; });
                    count++;

                }
                this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("completed task 2\n")); });
                this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("t2...{0}/{1}  time uptill now {2}\n", count, targetFilesLength, sw.Elapsed)); });
            }
            catch (Exception x)
            {

            }
            finally
            {
                this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("Best Match {0} ", matchedfile)); });
            }
        }

        #endregion

        #region good code


        /// <summary>
        /// gets all files inside the folderpath that is passed and selects files of the type that
        /// is passed to this method the default type is '.txt'
        /// </summary>
        /// <param name="folderpath"></param>
        /// <param name="filetype"></param>
        /// <returns></returns>
        private string[] GetFileCollection(string folderpath, string filetype = "txt")
        {
            try
            {
                string[] fileEntries = Directory.GetFiles(folderpath, "*." + filetype);
                return fileEntries;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// opens the folder dialog and returns the string of the folderpath if it is selected otherwise
        /// it returns String.Empty
        /// </summary>
        /// <returns></returns>
        private string OpenFolder()
        {
            FolderBrowserDialog folderBrowserDialog;
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// clears the logbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            LogBox.Text = string.Empty;
        }

        private void LogBox_TextChanged(object sender, EventArgs e)
        {
            LogBox.SelectionStart = LogBox.Text.Length;
            // scroll to bottom of textbox automatically
            LogBox.ScrollToCaret();

        }

        private void ExportLogButton_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllLines("Log.txt", LogBox.Lines);
                LogBox.AppendText("Exported Log !" + Environment.NewLine);
            }
            catch(Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }


       

       
        




     


      
       private void button1_Click(object sender, EventArgs e)
       {


           StreamReader srm = null;
           StringBuilder builder = new StringBuilder();
           try
           {
               

               filetomatch = openFile();
               if (filetomatch != string.Empty)
               {
                   LogBox.AppendText(String.Format("Loading Target File {0} please wait\n", filetomatch));
                   textBox1.Text = filetomatch;
                   srm = File.OpenText(filetomatch);
                   {
                       while (!srm.EndOfStream)
                       {
                           builder.Append((srm.ReadLine()));
                       }

                       srm.DiscardBufferedData();
                       srm.Close();

                   }

                   filetomatchwords = builder.ToString().Split(' ').ToList();
                   LogBox.AppendText(String.Format("Loaded  Target File {0} ", filetomatch));
               }
               else
               {
                   //
               }
           }
           catch (Exception x)
           {
               Console.WriteLine(x.Message);
           }
           finally
           {
               if (srm != null)
               { srm.Dispose(); }
               builder.Clear();
           }
         
       }
        

        private string openFile()
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            else
            {
                return string.Empty;
            }
        }


        


        private void button2_Click(object sender, EventArgs e)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(this.Right-10, this.Top);
            form.Height = this.Height;
            form.Show();
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if(form!=null)
            form.Location = new Point(this.Right-10,this.Top);
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutForm x = new AboutForm();
            x.ShowDialog(this);
        }
        #endregion


    }
}