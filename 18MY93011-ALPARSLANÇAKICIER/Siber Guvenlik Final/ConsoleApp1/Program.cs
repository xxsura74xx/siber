using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    class Program
    {
        class NMAP : IDisposable
        {
            private ProcessStartInfo GammaLIan = new ProcessStartInfo();
            private Process GM = new Process();
            private string output;
            private string script;
            public NMAP(string script)
            {
                this.script = script;
                GammaLIan.Arguments = "-p 80 --script " + this.script + " testphp.vulnweb.com -oX -";
                GammaLIan.RedirectStandardOutput = true;
                GammaLIan.FileName = "nmap";
                GM.StartInfo = ps;
            }

            public void Dispose()
            {
                GM.Dispose();
            }

            private void TakeOutput()
            {
                if (string.IsNullOrEmpty(output))
                {
                    GM.Start();
                    output = p.StandardOutput.ReadToEnd();
                    GM.WaitForExit();
                    GM.Close();
                }
            }
            public string StdOut
            {
                get
                {
                    TakeOutput();
                    return output;
                }
            }
        }
        static void Main(String[] args)
        {
            List<NMAP> nmaps = new List<NMAP>();
            nmaps.Add(new NMAP("http-sql-injection"));
            nmaps.Add(new NMAP("ssl-ccs-injection"));
            nmaps.Add(new NMAP("http-csrf"));
            //nmaps.ForEach(x => Console.WriteLine(x.StdOut));
            StreamWriter BM = new StreamWriter("result.xml");
            nmaps.ForEach(x => BM.WriteLine(x.StdOut));
            BM.Flush();
            BM.Close();
        }
    }
}
