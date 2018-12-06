using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501SemesterScheduler
{
    class Verify
    {
        Semester local;
        string fileName;
        Semester SIS;

        public Verify(string f, Semester l)
        {
            fileName = f;
            local = l;
        }

        public Verify(Semester l, Semester sis)
        {
            local = l;
            SIS = sis;
        }

        public Semester getFile()
        {
            ReadFile r = new ReadFile(fileName);
            SIS = r.readFile();
            return SIS;
        }
        
        public List<string> getErrors()
        {
            List<string> errors = new List<string>();
            bool flag = false;
            string[,] localCont = local.getContents();
            string[,] SISCont = SIS.getContents();
            for(int i = 0; i < localCont.Length; i++)
            {
                bool flagSection = false;
                for (int k = 0; k < SISCont.Length; k++)
                {
                    if(localCont[i,1] == SISCont[k,1])
                    {
                        if(localCont[i,2] == SISCont[k,2])
                        {
                            flagSection = true;
                            break;
                        }
                    }
                }
                if (!flagSection)
                {
                    flag = true;
                    errors.Add("<< Section CIS " + localCont[i,1] + " " + localCont[i,2] + " not found in current semester!");
                }
            }
            for (int i = 0; i < SISCont.Length; i++)
            {
                bool flagSection = false;
                for (int k = 0; k < localCont.Length; k++)
                {
                    if (localCont[i,1] == SISCont[k,1])
                    {
                        if (localCont[i,2] == SISCont[k,2])
                        {
                            flagSection = true;
                            break;
                        }
                    }
                }
                if (!flagSection)
                {
                    flag = true;
                    errors.Add("<< Section CIS " + SISCont[i,1] + " " + SISCont[i,2] + " is new in current semester!");
                }
            }
            if (!flag)
            {
                errors.Add("Success");
            }
            return errors;
        }

    }
}
