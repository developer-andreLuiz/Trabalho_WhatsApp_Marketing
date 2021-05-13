using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp_Marketing.Service
{
    class InternetService
    {
        public static void Habilitar()
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "ipconfig";
                info.Arguments = "/renew"; // or /release if you want to disconnect
                info.WindowStyle = ProcessWindowStyle.Hidden;
                Process p = Process.Start(info);
                p.WaitForExit();
            }
            catch { }
        }
        public static void Desabilitar()
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "ipconfig";
                info.Arguments = "/release"; // or /release if you want to disconnect
                info.WindowStyle = ProcessWindowStyle.Hidden;
                Process p = Process.Start(info);
                p.WaitForExit();
            }
            catch { }
        }
    }
}
