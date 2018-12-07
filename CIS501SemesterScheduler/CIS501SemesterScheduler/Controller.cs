using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501SemesterScheduler
{
    class Controller
    {
        public Semester local;
        public Semester SIS;

        public Controller()
        {

        }
        
        public void Clear()
        {
            Clear c = new Clear(out local, out SIS);
            c.ClearEverything();
        }

        public List<string> Reload()
        {
            Reload r = new Reload(local, SIS);
            return r.reloadSemesters();
        }

        public void Load(string fileName)
        {
            LoadFile lf = new LoadFile(fileName);
            local = lf.LoadSemester();
        }

        public string About()
        {
            About a = new About();
            return a.giveDescription();
        }

        public List<string> Verify(string fileName)
        {
            Verify v = new Verify(fileName, local);
            SIS = v.getFile();
            return v.getErrors();
        }
    }
}
