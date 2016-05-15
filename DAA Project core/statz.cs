using System;
namespace DAA_Project_core
{
    public class statz
    {
        public string file_name;
        public double ratio;

        public statz(double ratio, string file)
        {
            this.ratio = ratio;
            this.file_name = file;
        }

        public string getFile(){
            return this.file_name;
        }

        public double getRatio(){
            return this.ratio;
        }
        public void setfile(string file)
        {
            this.file_name = file;
        }

        public void setRatio(double ratio)
        {
            this.ratio = ratio;
        }
    }
}

