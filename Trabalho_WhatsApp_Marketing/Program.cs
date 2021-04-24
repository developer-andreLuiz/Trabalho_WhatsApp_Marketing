using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_WhatsApp_Marketing.Service;
using Trabalho_WhatsApp_Marketing.View;

namespace Trabalho_WhatsApp_Marketing
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FolderService.CreateFolderEmuladores();
            FolderService.CreateFolderTabelas();
            Application.Run(new FrmMain());
        }
    }
}
