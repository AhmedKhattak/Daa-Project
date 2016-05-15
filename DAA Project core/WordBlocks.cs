using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAA_Project_core
{
    /// <summary>
    /// class for a wordblock which contains 'windowsize' number of words 
    /// ie wordblock1:"aaa","eew","131","sasad","sasaasas" if windowsize=5
    /// </summary>
    class WordBlocks
    {
        private List<string> wordBlock;

        public  List<string> wordblock { get { return wordBlock; } }

        public  WordBlocks(List<string> wordblock)
        {
            //problem code line : wordBlock = wordblock; this is incorrect
            wordBlock =new List<string>(wordblock); //this fixed the problem with the wordblocks being empty

        }
       

    }
}
