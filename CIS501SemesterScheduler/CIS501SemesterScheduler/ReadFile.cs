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
            var lineCount = File.ReadAllLines(fileName).Length;
            string[,] contents = new string[lineCount,23];
            StreamReader file = new StreamReader(fileName);
            string name = file.ReadLine();
            name = name.Substring(0, name.IndexOf(','));
            int i = 0;
            file.ReadLine();
            while (!file.EndOfStream)
            {
                int k = 0;
                //bool passed = false;
                string txt = file.ReadLine();
                Regex regx = new Regex(',' + "(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                string[] split = regx.Split(txt);
                foreach(string seperated in split)
                {
                    contents[i, k] = seperated;
                    k++;
                }
                /*Console.WriteLine(txt);
                while(txt.Length > 0)
                {
                    if (txt.IndexOf('"') < txt.IndexOf(',') && !passed)
                    {
                        contents[i, k] = txt.Substring(0, txt.IndexOf(',', txt.IndexOf(',')));
                        txt = txt.Substring(txt.IndexOf(',', txt.IndexOf(',')));
                        passed = true;
                    }
                    else
                    {
                        if(txt.IndexOf(',') != -1)
                        {
                            contents[i, k] = txt.Substring(0, txt.IndexOf(','));
                            Console.WriteLine(i + " " + k);

                            txt = txt.Substring(txt.IndexOf(','));
                        }
                        else
                        {
                            contents[i, k] = txt;
                            txt = "";
                        }
                    }
                    k++;
                }*/
                i++;
            }
            Semester s = new Semester(name, contents, fileName);
            return s;
        }
    }
}
