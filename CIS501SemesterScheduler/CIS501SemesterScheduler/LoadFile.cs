using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501SemesterScheduler
{
    class LoadFile
    {
        string fileName;

        public LoadFile(string f)
        {
            fileName = f;
        }

        public Semester LoadSemester()
        {
            ReadFile r = new ReadFile(fileName);
            return r.readFile();
        }
    }
}
