namespace DAA_Project_core
{
    class FileObject
    {
        public string fileName;

       
        public string fileContentstring;


        public double ratio=0.0;


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
