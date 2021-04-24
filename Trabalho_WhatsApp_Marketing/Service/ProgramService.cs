using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp_Marketing.Service
{
    class ProgramService
    {
        public static void OpenEmulador(string name)
        {
            CloseEmulador();
            string path = FolderService.PathEmuladores + "\\" + name+ ".lnk";
            System.Diagnostics.Process.Start(path);
            Thread.Sleep(TimeSpan.FromSeconds(60));
        }
        public static void CloseEmulador()
        {
            try
            {
                string processName = "Memu";
                Process[] processos = Process.GetProcesses();

                foreach (Process p in processos)
                {
                    if (p.ProcessName.ToUpper() == processName.ToUpper())
                    {
                        if (!p.CloseMainWindow())
                        {
                            p.Kill();
                        }
                        p.Close(); // Libera recursos associados.
                    }


                }
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
            catch { }
        }
     
    }
}
