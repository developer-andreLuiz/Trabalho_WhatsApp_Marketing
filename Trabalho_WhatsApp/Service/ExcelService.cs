﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp.Service
{
    class ExcelService
    {
        public static string Contatos
        {
            get
            {
                return "Contatos";
            }
        }
        public static string Contatos_Email
        {
            get
            {
                return "Contatos_Email";
            }
        }
        public static string Path(string table)
        {
            return FolderService.PathTabelasExportadas + $"\\{table}.csv";
        }
        private static void Delete(string table)
        {
            string path = FolderService.PathTabelasExportadas + $"\\{table}.csv";
            if (System.IO.File.Exists(path))
            {
                try
                {
                    System.IO.File.Delete(path);
                }
                catch { }
            }
        }

        private static string Formato(int n)
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
                default: retorno = "C" + valor; break;
            }
            return retorno;
        }

        public static bool CreateTableContatos(List<string> List)
        {
            if (List.Count > 0)
            {
                FolderService.CreateFolderTabelas();
                Delete(Contatos);
                StringBuilder excel = new StringBuilder();
                excel.AppendLine("First Name,Mobile Phone");
                int numero = 0;

                foreach (var item in List)
                {
                    numero++;

                    excel.AppendLine($"{Formato(numero)},{item}");
                }
                File.AppendAllText(Path(Contatos), excel.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CreateTableContatosEmail(List<string> List)
        {
            if (List.Count > 0)
            {
                FolderService.CreateFolderTabelas();
                Delete(Contatos_Email);
                StringBuilder excel = new StringBuilder();
                excel.AppendLine("First Name,Mobile Phone");
                int numero = 0;

                foreach (var item in List)
                {
                    numero++;

                    excel.AppendLine($"{Formato(numero)},{item}");
                }
                File.AppendAllText(Path(Contatos_Email), excel.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
