using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501SemesterScheduler
{
    class Reload
    {
        Semester local;
        Semester SIS;

        public Reload(Semester l, Semester sis)
        {
            local = l;
            SIS = sis;
        }

        public string[] reloadSemesters()
        {
            ReadFile rLocal = new ReadFile(local.getFileName());
            ReadFile rSIS = new ReadFile(SIS.getFileName());
            local = rLocal.readFile();
            SIS = rSIS.readFile();
            Verify v = new Verify(local, SIS);
            return v.getErrors();
        }
    }
}
