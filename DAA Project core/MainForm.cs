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
        ///////////////////////////////////////////////////////////////////////////////
        List<statz> list = new List<statz>();
        List<statz> list2 = new List<statz>();
        private List<string> li = new List<string>();
        string str2 = "nope";
        Progress<string> progressIndicator2;
        static int count = 0;
       
     
        public MainForm()
        {
            InitializeComponent();
            form = new LogForm(this);
            progressIndicator2 = new Progress<string>(new Action<string>(ReportProgress2));
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

                
                //help from http://stackoverflow.com/questions/14388136/how-to-use-begininvoke-c-sharp
                //used for updating the UI
                sw.Start();
                targetFilesLength = targetfiles.Length;
                //size of bocking collection is preset to avoid resizing the internal array
                BC2 = new BlockingCollection<FileObject>(targetFilesLength);
               
                //LogBox.AppendText("\n");

                string text;
                int x = await processing_thread(windowSize, targetfiles, progressIndicator2);
                text =  await generating_unified_task();  //done fucking shit
                LogBox.AppendText(text);
                LogBox.AppendText(sw.Elapsed.ToString());
                //do everything in seprate thread from ui
                //var task_1 = Task.Factory.StartNew(() =>
                // {
                //     //all the calculations happen here
                //     fuck1();

                // });

                ////according to stackoverflow finally blocks do not work in background threads 
                ////since all task factory threads are placed in the threadpool and the threadpool handles
                ////background threads there is no finally block here any disposal must happen inside catch or try block
                //var task_2 = Task.Factory.StartNew(() =>
                //{

                //    fuck2();

                //}).ContinueWith((ok)=>{

               
                  


                //});

            }
        }

        #region consumer-producer wala code


        private void fuck1()
        {
            

            var splitter = new StringSplitter(4000);
            int count = 0;
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
                    //this.Invoke((MethodInvoker)delegate { FilesLeft.Text = targetFilesLength + "/" + count; });
                    //count++;
                }
                    
                
               
                     
                    
                     //Array.Clear(splitter.buffer, 0, splitter.buffer.Length);
                    
                
                //this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("completed task 1\n")); });
                //this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("t1...{0}/{1}  time uptill now {2}\n", count, targetFilesLength, sw.Elapsed)); });
               
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


        private void fuck2()
        {
            int count = 1;
            try
            {

                this.Invoke((MethodInvoker)delegate { LogBox.AppendText(String.Format("started task 2\n")); });
                var splitter = new StringSplitter(10000);
                foreach (var x in BC2.GetConsumingEnumerable())
                {


                    splitter.SafeSplit(x.FileContentstring, ' ');
                    x.FileContentstring = string.Empty;
                    if (((double)filetomatchwords.Intersect(splitter.Results).Count() / (double)filetomatchwords.Union(splitter.Results).Count()) > threshold)
                    {
                        matchedfile = x.FileName;
                    }
                    hugeList.Add(splitter.Results);
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



        #region async version is faster than consumer producer how ???



        public void ReportProgress2(string text)
        {
            count++;
            FilesLeft.Text = targetFilesLength + "/" + count;
        }

        /// <summary>
        /// i duntknow wtff
        /// </summary>
        /// <param name="input_filename"></param>
        /// <returns></returns>
        public async Task<string> processing_unified() { return await generating_unified_task(); }




        /// <summary>
        /// done fucking shit
        /// </summary>
        /// <param name="windowsize"></param>
        /// <param name="targetFiles"></param>
        /// <param name="progress2"></param>
        /// <returns></returns>
        public async Task<int> processing_thread(int windowsize, string[] targetFiles, IProgress<string> progress2)
        {
            return await Task.Run<int>(delegate
            {
                int num1 = 0;
                foreach (var file in targetFiles)
                {
                    WriteProcessedFiles(file, windowsize);
                    num1++;
                    progress2.Report(file);

                }
                return num1;
            });
        }

        // writes processed files
        private async Task WriteProcessedFiles(string file, int windowsize)
        {

            int counter = 1;
            string words = File.ReadAllText(file);
            string[] wordsarray = words.Split(' ');
            try
            {
                using (StreamWriter filewriter = new StreamWriter(file+"fuck"))
                {

                    for (int x = 0; x < wordsarray.Length; x++)
                    {

                        if (counter == windowsize)
                        {
                            filewriter.WriteLine();
                            counter = 1;
                        }
                        else
                        {
                            filewriter.Write(wordsarray[x] + " ");
                            counter++;
                        }
                    }

                }
            }
            catch (Exception x)
            {

            }

           
        }

        private async Task<string> generating_unified_task()
        {

            HashSet<string> set1 = new HashSet<string>(filetomatchwords);
            HashSet<string> set2 = null;
            IEnumerable<string> enumerable = null;
            string[] array1;
            double ratio = 0.0;
            try
            {
                foreach (var file in targetfiles)
                {
                    array1 = File.ReadAllLines(file);
                    enumerable = array1.Intersect<string>(filetomatchwords);
                    set2 = new HashSet<string>(array1.ToList<string>());
                    ratio = ((double)set1.Intersect<string>(set2).Count<string>()) / ((double)set1.Union<string>(set2).Count<string>());
                    float num3 = float.Parse(ratio.ToString());
                    MinHash hash = new MinHash(set1.Count + set2.Count);
                    list2.Add(new statz(hash.Similarity<string>(set1, set2), file));
                    list.Add(new statz(ratio, file));
                    using (IEnumerator<string> enumerator = enumerable.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            string item = enumerator.Current;
                            if (!this.li.Contains(item))
                            {
                                li.Add(item);
                            }
                        }
                    }
                    File.WriteAllLines("unified.txt", li);
                    statz current;
                    double num4 = -2147483648.0;
                    List<statz>.Enumerator enumerator2 = list.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            current = enumerator2.Current;
                            if (current.ratio > num4)
                            {
                                num4 = current.ratio;
                            }
                        }
                    }
                    finally
                    {
                        enumerator2.Dispose();
                    }

                    string str8 = null;
                    int num5;
                    for (num5 = 0; num5 < list.Count; num5++)
                    {
                        if (list.ElementAt<statz>(num5).getRatio() == num4)
                        {
                            str8 = list.ElementAt<statz>(num5).getFile().ToString();
                        }
                    }
                    string str9 = null;
                    double num6 = -2147483648.0;
                    enumerator2 = list2.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            current = enumerator2.Current;
                            if (current.ratio > num6)
                            {
                                num6 = current.ratio;
                            }
                        }
                    }
                    finally
                    {
                        enumerator2.Dispose();
                    }
                    for (num5 = 0; num5 < list2.Count; num5++)
                    {
                        if (list.ElementAt<statz>(num5).getRatio() == num6)
                        {
                            str9 = list2.ElementAt<statz>(num5).getFile().ToString();
                        }
                    }
                    str2 = "Best Match Matrix | " + str8.ToString() + " | Ratio :  " + num4.ToString() + Environment.NewLine + "Minhash Ratio : " + num6.ToString() + " | File Name : " + str9.ToString();
                }
            }
            catch (Exception s)
            {

            }
            finally
            {
                li.Clear();
                ratio = 0.0;


            }
            return str2;
        }
        #endregion




        #region puranay wale parts

        /// <summary>
        /// update ui from here and get changes from the background thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            try
            {
                if (e.UserState is int)
                {
                    FilesLeft.Text = targetfiles.Length + "/" + e.UserState;
                }

                else if (e.UserState is string)
                {
                    LogBox.AppendText(String.Format("{0}" + Environment.NewLine, e.UserState));
                }
                else if (e.UserState is TimeSpan)
                {
                    TimeSpan waqt = (TimeSpan)e.UserState;
                    LogBox.AppendText(String.Format("Time elapsed: {0:hh\\:mm\\:ss}" + Environment.NewLine, waqt));
                }

                else
                {
                    LogBox.AppendText("This text is not supposed to appear here something has gone horribly wrong !" + Environment.NewLine);
                }
            }
            catch (Exception x)
            {
                LogBox.AppendText("This text is not supposed to appear here something has gone horribly wrong !" + Environment.NewLine);

                Console.WriteLine(x);
            }
        }

        /// <summary>
        /// do stuff when the worker is completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LogBox.AppendText("Completed Execution" + Environment.NewLine);
        }


        public async Task<string> wtf(String[] malun, string filename)
        {
            //MessageBox.Show(malun.Length.ToString());
            if (((double)filetomatchwords.Intersect(malun).Count() / (double)filetomatchwords.Union(malun).Count()) > threshold)
            {
                // filetomatchwords.Clear();
                // malun.Clear();

                //Array.Clear(malun,0,malun.Length);
                return filename;
            }
            else
            {
                //filetomatchwords.Clear();
                //malun.Clear();

                return string.Empty;
            }




        }
        /// <summary>
        /// the stuff to do when RunWorkerAsync(); is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void bw_DoWork(object sender, DoWorkEventArgs e)
        {



            
            //StringBuilder builder = new StringBuilder();
            //StreamReader sr = null;
            //String[] malun;
            //string directory = string.Empty;
            //int counter = 1;
           
           
          
            ////var blockingCollection = new BlockingCollection<List<string>>();
            //try
            //{
               
               
                
            //   // string filecontents = string.Empty;
            //   // Directory.CreateDirectory(Path.GetDirectoryName(targetfiles[0]) + "Processed files");
            //   //irectory = Path.GetDirectoryName(targetfiles[0]) + @"\Processed files";
            //   //MsageBox.Show(directory);
            //  // MessageBox.Show(Directory.CreateDirectory(Path.GetDirectoryName(targetfiles[0])));

            //    //bw.ReportProgress(0, "Execution Started");
            //    int z = 0;
            //    // generate words for each file
            //    foreach (string file in targetfiles)
            //    {
            //        //var x = GenerateWordsFromFile(file);
            //        //if (x != null)
            //        //{
            //        //    processedFileList.Add(x);
            //        //    bw.ReportProgress(0, x);
            //        //    //GenerateProcessedFileOnDisk(processedFileList[z], windowSize);
            //        //    GenerateUnformatedFileOnDiskVeryQuickly(processedFileList[z],windowSize);
            //        //    processedFileList[z].FileWords = null;
            //        //    bw.ReportProgress(0, z + 1);
            //        //    z++;

            //        //}
            //        //sr = File.OpenText(file);
            //        //{ 
            //        //    while (!sr.EndOfStream)
            //        //    {
            //        //        builder.Append((sr.ReadLine()));
            //        //    }

            //        //    sr.DiscardBufferedData();
            //        //    sr.Close();

            //        //}
            //        var lines = File.ReadLines(file);
            //        foreach (var line in lines)
            //        {
            //            builder.Append(line);
            //        }
            //        lines = null;

            //        //const Int32 BufferSize = 128;
            //        //using (var fileStream = File.OpenRead(file))
            //        //{
            //        //    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            //        //    {
            //        //        String line;
            //        //        while ((line = streamReader.ReadLine()) != null)
            //        //        {
            //        //            builder.Append(line);
            //        //        }
            //        //        // Process line
            //        //    }
            //        //}
            //        //MessageBox.Show(builder.Length.ToString());
            //        malun = builder.ToString().Split(' ');
            //        //MessageBox.Show(malun.Length.ToString());
                    
            //        //GC.Collect();
            //        //blockingCollection.Add(builder.ToString().Split(' ').ToList());
            //        // MessageBox.Show(malun.Count.ToString());
            //        matchedfile = await wtf(malun, file);
            //        //using (StreamWriter writer = new StreamWriter(file + ".proc"))
            //        //{
            //        //    for (int x = 0; x < malun.Length; x++)
            //        //    {
            //        //        if (counter == windowSize)
            //        //        {
            //        //            writer.WriteLine();
            //        //            counter = 1;
            //        //        }
            //        //        else
            //        //        {
            //        //            writer.Write(malun[x] + " ");

            //        //            counter++;
            //        //        }
            //        //    }

            //        //}


                    

                 
                   
            //        //bw.ReportProgress(0, "awaiting");

            //        malun = null;
            //        //malun.Clear();
            //        builder.Clear();
            //       // bw.ReportProgress(0, z+1);
            //        //bw.ReportProgress(0, file);
            //        z++;
            //        //Thread.Sleep(5);
            //    }

            //    ////le parallel for loop for making the cpu a frighten !
            //    //Parallel.For(0, targetfiles.Length, yy =>
            //    //{
            //    //    var x = GenerateWordsFromFile(targetfiles[yy]);
            //    //    if (x != null)
            //    //    {
            //    //        processedFileList.Add(x);
            //    //        bw.ReportProgress(0, x);
            //    //        GenerateProcessedFileOnDisk(processedFileList[z], windowSize);
            //    //        processedFileList[z].FileWords = null;
            //    //        bw.ReportProgress(0, z + 1);
            //    //    }
            //    //});
            //    //z = 0;
            //    //////write file to disk in XML format
            //    //foreach (ProcessedFile proc in processedFileList)
            //    //{

            //    //    GenerateUnformatedFileOnDiskVeryQuickly(proc, windowSize);
            //    //    proc.FileWords = null;
            //    //    //processedFileList[z].FileWords = null;
            //    //    bw.ReportProgress(0, z);
            //    //    z++;
                   
            //    //}

            //    // generate unified file
            //    // GenerateUnifiedFile();

            //    // generate matrix representation
            //    // GenerateMatrix();

            //    //finish and get output


            //            //Task.Factory.StartNew(() =>
            //            //{

            //            //    foreach (var value in blockingCollection.GetConsumingEnumerable())
            //            //    {

            //            //        if (((double)value.Intersect(value).Count() / (double)value.Union(value).Count())==1)
            //            //        {
            //            //            MessageBox.Show("found a match");
            //            //        }
            //            //        value.Clear();
                             
            //            //    }



            //            //});





            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{

            //   // stopWatch.Stop();
            //   // bw.ReportProgress(0, String.Format("Time Elapsed {0}", stopWatch.Elapsed.ToString()));
            //   // bw.ReportProgress(0, String.Format("Best Match {0}",matchedfile));



            //}
            



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


        #endregion

        private void iconButton1_Click(object sender, EventArgs e)
        {
            AboutForm frm2 = new AboutForm();
            frm2.ShowDialog(this);
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
    }
}