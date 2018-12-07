using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS501SemesterScheduler
{
    class ReadFile
    {
        string fileName;

        public ReadFile(string f)
        {
            fileName = f;
        }

        public Semester readFile()
        {
            if(fileName != "")
            {
                var lineCount = File.ReadAllLines(fileName).Length;
                string[,] contents = new string[lineCount, 23];
                StreamReader file = new StreamReader(fileName);
                string name = file.ReadLine();
                name = name.Substring(0, name.IndexOf(','));
                int i = 0;
                file.ReadLine();
                while (!file.EndOfStream)
                {
                    int k = 0;
                    string txt = file.ReadLine();
                    Regex regx = new Regex(',' + "(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    string[] split = regx.Split(txt);
                    foreach (string seperated in split)
                    {
                        contents[i, k] = seperated;
                        k++;
                    }
                    i++;
                }
                Semester s = new Semester(name, contents, fileName);
                return s;
            }
            MessageBox.Show("Please Load the appropiate file types.");
            return null;
        }
    }
}
