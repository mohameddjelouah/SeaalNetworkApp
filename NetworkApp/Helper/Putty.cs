using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Helper
{
    public static class Putty
    {
        public static List<Process> Processes = new List<Process>();
        public static void puttySsh(string add)
        {


            ProcessStartInfo cmd = new ProcessStartInfo(Path.Combine(Path.GetTempPath(), "putty.exe"));
            cmd.UseShellExecute = false;
            cmd.RedirectStandardInput = true;
            cmd.RedirectStandardOutput = true;
            cmd.Arguments = "-ssh @" + add + " 22";
            Process _process = Process.Start(cmd);
            Processes.Add(_process);

        }

        public static void puttyTelnet(string add)
        {


            ProcessStartInfo cmd = new ProcessStartInfo(Path.Combine(Path.GetTempPath(), "putty.exe"));
            cmd.UseShellExecute = false;
            cmd.RedirectStandardInput = true;
            cmd.RedirectStandardOutput = true;
            cmd.Arguments = "-telnet @" + add + " 23";
            Process _process = Process.Start(cmd);
            Processes.Add(_process);

        }

        public static void RemoveExitedProcess()
        {
            foreach (var process in Processes.ToList())
            {
                if (process.HasExited)
                {

                    Processes.Remove(process);

                }


            }
        }


        public static void killProcess()
        {
            foreach (var process in Processes)
            {
                if (!process.HasExited)
                {
                 
                    process.Kill();
                    
                }
               

            }

        }

        

    }
}
