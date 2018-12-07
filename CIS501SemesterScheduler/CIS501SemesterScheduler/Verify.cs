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
            for (int i = 0; i < SISCont.GetLength(0); i++)
            {
                bool flagSection = false;
                for (int k = 0; k < localCont.GetLength(0); k++)
                {
                    if (localCont[k, 1] == SISCont[i, 1])
                    {
                        if (localCont[k, 3] == SISCont[i, 3])
                        {
                            flagSection = true;
                            break;
                        }
                    }
                }
                if (!flagSection)
                {
                    flag = true;
                    errors.Add(">> Section CIS " + SISCont[i, 1] + " Section " + SISCont[i, 3] + " is not found in current semester!\r\n");
                }
            }
            for (int i = 0; i < localCont.GetLength(0); i++)
            {
                bool flagSection = false;
                for (int k = 0; k < SISCont.GetLength(0); k++)
                {
                    if(localCont[i,1] == SISCont[k,1])
                    {
                        if(localCont[i,3] == SISCont[k,3])
                        {
                            flagSection = true;
                            break;
                        }
                    }
                }
                if (!flagSection)
                {
                    flag = true;
                    errors.Add("<< Section CIS " + localCont[i,1] + " Section " + localCont[i,3] + " is new in current semester!\r\n");
                }
            }
            for (int i = 0; i < localCont.GetLength(0); i++)
            {
                bool flagSection = false;
                for (int k = 0; k < SISCont.GetLength(0); k++)
                {
                    if (localCont[i, 1] == SISCont[k, 1])
                    {
                        if (localCont[i, 3] == SISCont[k, 3])
                        {
                            for(int m = 0; m < 23; m++)
                            {
                                if(localCont[i,m] != SISCont[k, m])
                                {
                                    flagSection = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (flagSection)
                {
                    flag = true;
                    errors.Add("Section CIS " + localCont[i, 1] + " Section " + localCont[i, 3] + " has been changed in the current semester.\r\n");
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
