using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501SemesterScheduler
{
    class Clear
    {
        Semester local;
        Semester SIS;

        public Clear(out Semester l, out Semester sis)
        {

            string[,] non = { { "" } };
            l = new Semester("", non, "");
            sis = new Semester("", non, "");
        }

        public void ClearEverything()
        {
            string[,] non = { { "" } };
            local = new Semester("",non,"");
            SIS = new Semester("", non,"");
        }
    }
}
