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

        public Clear(Semester l, Semester sis)
        {
            local = l;
            SIS = sis;
        }

        public void ClearEverything()
        {
            string[,] non = { { "" } };
            local = new Semester("",non);
            SIS = new Semester("", non);
        }
    }
}
