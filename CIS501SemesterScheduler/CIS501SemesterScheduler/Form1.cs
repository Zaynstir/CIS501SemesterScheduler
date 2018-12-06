using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS501SemesterScheduler
{
    public partial class Form1 : Form
    {
        Semester local;
        Semester SIS;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Clear c = new Clear(local, SIS);
            c.ClearEverything();
        }

        private void button_Reload_Click(object sender, EventArgs e)
        {
            Reload r = new Reload(local, SIS);
            string[] ray = r.reloadSemesters();
            text_Output.Text = "";
            for (int i = 0; i < ray.Length; i++)
            {
                text_Output.Text += ray[i];
            }
            text_Local.Text = local.getFileName();
            text_KSIS.Text = SIS.getFileName();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                LoadFile lf = new LoadFile(fileName);
                local = lf.LoadSemester();
                text_Local.Text = local.getFileName();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            text_Output.Text = a.getDescription();
        }

        private void verifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                Verify v = new Verify(fileName);
                SIS = v.GetFile();
                v.GetErrors();
                string[] ray = text_Output.Text = "";
                for (int i = 0; i < ray.Length; i++)
                {
                    text_Output.Text += ray[i];
                }
                text_Local.Text = local.getFileName();
                text_KSIS.Text = SIS.getFileName();
            }
        }
    }
}
