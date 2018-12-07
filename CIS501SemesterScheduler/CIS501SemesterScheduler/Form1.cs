using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS501SemesterScheduler
{
    public partial class Form1 : Form
    {
        Controller c;

        public Form1()
        {
            InitializeComponent();
            c = new Controller();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            c.Clear();
            text_Output.Text = "Memory has been Cleared";
        }

        private void button_Reload_Click(object sender, EventArgs e)
        {
            List<string> ray = c.Reload();
            text_Output.Text = "";
            foreach (string txt in ray)
            {
                text_Output.Text += txt;
            }
            text_Local.Text = c.local.getFileName();
            text_KSIS.Text = c.SIS.getFileName();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                c.Load(fileName);
                text_Local.Text = c.local.getFileName();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text_Output.Text = c.About();
        }

        private void verifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                List<string> ray = c.Verify(fileName);
                text_Output.Text = "";
                foreach(string txt in ray)
                {
                    text_Output.Text += txt;
                }
                text_Local.Text = c.local.getFileName();
                text_KSIS.Text = c.SIS.getFileName();
            }
        }
    }
}
