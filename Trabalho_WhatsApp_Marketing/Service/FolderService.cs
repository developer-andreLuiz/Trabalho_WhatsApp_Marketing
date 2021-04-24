using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp_Marketing.Service
{
    class FolderService
    {
        public static string PathTabelas
        {
            get
            {
                return System.IO.Directory.GetCurrentDirectory() + @"\Tabelas";
            }
           
        }
        public static string PathEmuladores
        {
            get
            {
                return System.IO.Directory.GetCurrentDirectory() + @"\Emuladores";
            }

        }
        public static void CreateFolderTabelas()
        {
            if (Directory.Exists(PathTabelas)==false)
            {
                Directory.CreateDirectory(PathTabelas);
            }
        }
        public static void CreateFolderEmuladores()
        {
            if (Directory.Exists(PathEmuladores) == false)
            {
                Directory.CreateDirectory(PathEmuladores);
            }
        }
    }
}
