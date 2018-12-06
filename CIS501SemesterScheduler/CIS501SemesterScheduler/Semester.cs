using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501SemesterScheduler
{
    class Semester
    {
        string[,] Contents;
        string fileName;
        string Name;

        public Semester(string s, string[,] SC, string f)
        {
            Name = s;
            Contents = SC;
            fielName = f;
        }

        public string getName()
        {
            return Name;
        }

        public string[,] getContents()
        {
            return Contents;
        }

        public string getFileName()
        {
            return fileName;
        }
    }
}
