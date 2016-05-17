namespace DAA_Project_core
{
    class FileObject
    {
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private string fileContentstring;

        public string FileContentstring
        {
            get { return fileContentstring; }
            set { fileContentstring = value; }
        }



        public FileObject(string filename, string filecontentstring)
        {
            fileName = filename;
            fileContentstring = filecontentstring;
        }

        ~FileObject()
        {
            fileName = string.Empty;
            fileContentstring = string.Empty;
        }


    }
}
