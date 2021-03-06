﻿using System;
using System.Diagnostics;     //for stopwatch timers
using System.IO;              //for file io
using System.Text;            //for string manipulation
using System.Windows.Forms;   //for forms 
using System.Threading.Tasks; //for task parallel library
using System.Collections.Generic; //for enumerable lists
using System.Linq;  //for linq queries
using System.Collections.Concurrent; //for thread safe blocking collections
using System.Drawing; //for widgets on the form
namespace DAA_Project_core
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// organized fields according to their types and near types
        /// </summary>
        private string targetFolderPath = string.Empty;
        string filetomatch;
        string outPutFolderPath = string.Empty;
        private int windowSize = 0;
        int targetFilesLength = 0;
        private string[] targetfiles=null;
        List<string> filetomatchwords = new List<string>();
        List<FileObject> listOfFileObjects= new List<FileObject>();
        BlockingCollection<FileObject> BC2;
        LogForm form;
        AboutForm about;
        Stopwatch sw = new Stopwatch();
       
        public MainForm()
        {
            InitializeComponent();
            //form = new LogForm(this);
            about = new AboutForm();
            increaseProcessPriority();
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(radioButton1,"This will be slower");
            tooltip.SetToolTip(radioButton2,"This will be faster");
            tooltip.SetToolTip(AboutButton, "About");

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
            targetFolderPath = FolderPathTextbox.Text;
            if(targetfiles!=null)
            { Array.Clear(targetfiles, 0, targetfiles.Length); }
            targetfiles = GetFileCollection(targetFolderPath);
            if (targetfiles != null)
            {
                if (targetfiles.Length != 0)
                    LogBox.AppendText(string.Format("Loaded {0} File Entries\n", targetfiles.Length));
            }
        }

        /// <summary>
        ///  every thing begins here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteButton_Click(object sender, EventArgs e)
        {

            //get window size and then go through checks
            windowSize = Convert.ToInt32(WindowsSizeSpinner.Value);
            listOfFileObjects.Clear();
            if (targetFolderPath == string.Empty)
            {
                LogBox.AppendText("Please select a valid target folder in order to continue !" + Environment.NewLine);
            }
            else if (windowSize == 0)
            {
                LogBox.AppendText("Window size must be greater than 0 !" + Environment.NewLine);
            }
            else if (filetomatchwords.Count == 0)
            {
                LogBox.AppendText("Please select a target file and wait for it to load !" + Environment.NewLine);
            }
            else if (outPutFolderPath==string.Empty)
            {
                LogBox.AppendText("Please select a valid output folder in order to continue  !" + Environment.NewLine);
            }
            else
            {
                sw.Reset();
                sw.Start();//start stopwatch
                targetFilesLength = targetfiles.Length;
                //size of bocking collection is preset to avoid resizing the internal array
                BC2=new BlockingCollection<FileObject>(targetfiles.Length);
                //do everything in seprate thread from ui
                var task_1 = Task.Factory.StartNew(() =>
                 {
                     //all the calculations happen here
                     t1();

                 });
                var task_2 = Task.Factory.StartNew(() =>
                {

                    t2();

                }).ContinueWith((ok)=> {


                    this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("finding file with largest ratio...\n")); });
                    var max = listOfFileObjects.OrderByDescending(o => o.ratio).First();
                    this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("Best Match : File {0} Ratio {1}\n", max.fileName, max.ratio)); });
                    max = null;
                    //listOfFileObjects.Clear();
                    
                    //foreach (var x in listOfFileObjects)
                    //{
                    //    this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("File {0} Ratio {1}\n", x.fileName, x.ratio)); });
                    //}


                });

            }
        }

        #region consumer-producer wala code



        /// <summary>
        /// adds fileobjects to the blocking collection
        /// </summary>
        private void t1()
        {
            StringBuilder builder = new StringBuilder();
            try
            {

                //int counter = 0;
                this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("started task 1\n")); });
                foreach (var file in targetfiles)
                {
                    foreach (string line in File.ReadLines(file))
                    {
                        builder.Append(line);
                    }
                    BC2.Add(new FileObject(file, builder.ToString()));
                    builder.Clear();
                    //this.Invoke((MethodInvoker)delegate { FilesLeft.Text = targetFilesLength + "/" + counter; });
                    //counter++;
                    

                }
                builder.Clear(); //clear any remaining data in builder
                BC2.CompleteAdding(); //tells the blocking collection that it should not expect any more data to be added to it
                //this ensures that the collection does not sit in an infinite blocking state

            }
            catch (Exception xx)
            {



            }
            finally
            {
                
            }
        }


        private void t2()
        {
            int count = 1;
            int counter = 0;
            try
            {

                this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("started task 2\n")); });
                string[] words;
                foreach (var x in BC2.GetConsumingEnumerable())
                {


                    words = x.fileContentstring.Replace(Environment.NewLine," ").Split(' ');
                    x.fileContentstring= string.Empty;
                    x.ratio =(double)(filetomatchwords.Intersect(words).Count() / (double)filetomatchwords.Union(words).Count());
                    Console.WriteLine();
                    if (radioButton1.Checked)
                    {
                        count = 1;
                        using (StreamWriter writer = new StreamWriter(outPutFolderPath + @"\" + Path.GetFileName(x.fileName)))
                        {
                            for (int xx = 0; xx < words.Length; xx++)
                            {

                                if (count == windowSize)
                                {
                                    writer.Write(words[xx] + " ");
                                    writer.WriteLine();
                                    count = 1;
                                }
                                else
                                {
                                    writer.Write(words[xx] + " ");
                                    count++;
                                }
                            }
                            

                        }
                        
                    }
                    counter++;
                    Array.Clear(words, 0, words.Length);
                    listOfFileObjects.Add(x);
                    //words = null;
                    this.Invoke((MethodInvoker)delegate { FilesLeft.Text = targetFilesLength + "/" + counter; });
                    count++;

                }
                this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("completed task 2\n")); });
                this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("t2...{0}/{1}  time uptill now {2}\n", counter, targetFilesLength, sw.Elapsed)); });
            }
            catch (Exception x)
            {

            }
            finally
            {
               
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
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }






        private async Task<string> ReadTextAsync(string filePath)
        {
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true))
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                return sb.ToString();
            }
        }

        private void  button1_Click(object sender, EventArgs e)
        {

            TargetFilePathTextBox.Text= openFile();
            filetomatch = TargetFilePathTextBox.Text;
            filetomatchwords.Clear();
            StreamReader srm = null;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (filetomatch != string.Empty)
                {
                    LogBox.AppendText(String.Format("Loading Target File {0} please wait\n", filetomatch));
                    srm = File.OpenText(filetomatch);
                    {
                        while (!srm.EndOfStream)
                        {
                            builder.Append((srm.ReadLine()));
                        }

                        srm.DiscardBufferedData();
                        srm.Close();

                    }

                    filetomatchwords = builder.ToString().Replace(Environment.NewLine, " ").Split(' ').ToList();
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
            form.Location = new Point(this.Right - 10, this.Top);
            form.Height = this.Height;
            form.Show();
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (form != null)
                form.Location = new Point(this.Right - 10, this.Top);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutForm x = new AboutForm();
            x.ShowDialog(this);
        }


        /// <summary>
        /// increase process priority may lead to faster execution as the program will have more time inside cpu
        /// </summary>
        private void increaseProcessPriority()
        {
            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
        }



        /// <summary>
        /// gets the output folder path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutPutFolderButton_Click(object sender, EventArgs e)
        {
            outPutFolderTextBox.Text = OpenFolder();
            outPutFolderPath = outPutFolderTextBox.Text;
        }


        ///// <summary>
        ///// double,float,float only textbox
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ThresholdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    char ch = e.KeyChar;
        //    if (ch == 46 && ThresholdTextBox.Text.IndexOf('.') != -1)
        //    {
        //        e.Handled = true;
        //        return;
        //    }

        //    if (!char.IsDigit(ch) && ch != 8 && ch != 46)
        //    {
        //        e.Handled = true;
        //    }
        //}

        #endregion


    }
}