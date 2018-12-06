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
        
        public string[] getErrors()
        {
            string[] errors;
            int m = 0;
            bool flag = false;
            for(int i = 0; i < local.Length; i++)
            {
                bool flagSection = false;
                for (int k = 0; k < SIS.Lenth; k++)
                {
                    if(local[i][1] == SIS[k][1])
                    {
                        if(local[i][2] == SIS[k][2])
                        {
                            flagSection = true;
                            break;
                        }
                    }
                }
                if (!flagSection)
                {
                    flag = true;
                    errors[m] = "<< Section CIS " + local[i][1] + " " + local[i][2] + " not found in current semester!";
                }
            }
            for (int i = 0; i < SIS.Length; i++)
            {
                bool flagSection = false;
                for (int k = 0; k < local.Lenth; k++)
                {
                    if (local[i][1] == SIS[k][1])
                    {
                        if (local[i][2] == SIS[k][2])
                        {
                            flagSection = true;
                            break;
                        }
                    }
                }
                if (!flagSection)
                {
                    flag = true;
                    errors[m] = "<< Section CIS " + SIS[i][1] + " " + SIS[i][2] + " is new in current semester!";
                }
            }
            if (!flag)
            {
                string[] ray = { "Success" };
                return ray;
            }
            else
            {
                return errors;
            }
            return "";
        }

    }
}
