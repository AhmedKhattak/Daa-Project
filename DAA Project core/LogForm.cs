using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAA_Project_core
{
    public partial class LogForm : Form
    {
        MainForm formRefrence;
        public LogForm(MainForm f1)
        {
            InitializeComponent();
            formRefrence = f1;
           
        }
    }
}
