using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace DAA_Project_core
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            InitToolTips();
        }

        private void BahriaLogo_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://aliashraf.net/");
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }

        private void BahriaLogo_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void BahriaLogo_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void GithubLogo_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void GithubLogo_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void GithubLogo_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/AhmedKhattak/Daa-Project");
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }

        private void InitToolTips()
        {
            ToolTip AboutForm_toolTip = new ToolTip();
            AboutForm_toolTip.SetToolTip(this.GithubLogo, "https://github.com/AhmedKhattak/Daa-Project");
            AboutForm_toolTip.SetToolTip(this.BahriaLogo, "http://aliashraf.net/");
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }
    }
}
