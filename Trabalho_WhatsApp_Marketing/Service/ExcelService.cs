using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp_Marketing.Service
{
    class ExcelService
    {
        public static string Verification
        {
            get
            {
                return "TabelaVerificacao";
            }
        }
        public static string Email
        {
            get
            {
                return "TabelaEmail";
            }
        }
        private static string Path(string table)
        {
            return FolderService.PathTabelas + $"\\{table}.csv";
        }
        private static void Delete(string table)
        {
            string path = FolderService.PathTabelas + $"\\{table}.csv";
            if (System.IO.File.Exists(path))
            {
                try
                {
                    System.IO.File.Delete(path);
                }
                catch { }
            }
        }
        public static bool CreateVerification()
        {   
            if (Global.ListContactsExcel.Count > 0)
            {
                FolderService.CreateFolderTabelas();
                Delete(Verification);
                StringBuilder excel = new StringBuilder();
                excel.AppendLine("First Name,Mobile Phone");
                int numero = 0;
                
                foreach (var item in Global.ListContactsExcel)
                {
                    numero++;

                    excel.AppendLine($"{Formato(numero)},{item}");
                }
                File.AppendAllText(Path(Verification), excel.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CreateEmail(List<string>List)
        {
            if (List.Count > 0)
            {
                FolderService.CreateFolderTabelas();
                Delete(Email);
                StringBuilder excel = new StringBuilder();
                excel.AppendLine("First Name,Mobile Phone");
                foreach (var item in List)
                {
                    excel.AppendLine($"{item},{item}");
                }
                File.AppendAllText(Path(Email), excel.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }
        static string Formato(int n)
        {
            string valor = n.ToString();
            string retorno = string.Empty;
            
            switch (valor.Length)
            {
                case 1: retorno = "C" + "0000" + valor; break;
                case 2: retorno = "C" + "000" + valor; break;
                case 3: retorno = "C" + "00" + valor; break;
                case 4: retorno = "C" + "0" + valor; break;
                case 5: retorno = "C" + valor; break;
                default: retorno = "C" + valor;break;
            }
            return retorno;
        }


    }
}
