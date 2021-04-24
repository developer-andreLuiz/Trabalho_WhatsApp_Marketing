using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp_Marketing.Model
{
    class Tb_contato_email_Model
    {
        public int id { get; set; }
        public string telefone { get; set; }
        public string emulador { get; set; }
        public int whatsapp { get; set; }
        public int business { get; set; }
        public int habilitado { get; set; }
        public Tb_contato_email_Model()
        {
            id = 0;
            telefone = string.Empty;
            emulador = string.Empty;
            whatsapp = 0;
            business = 0;
            habilitado = 0;
        }
        public Tb_contato_email_Model(string Telefone)
        {
            id = 0;
            telefone = Telefone;
            emulador = string.Empty;
            whatsapp = 0;
            business = 0;
            habilitado = 0;
        }
        public Tb_contato_email_Model(string Telefone,int Habilitatdo)
        {
            id = 0;
            telefone = Telefone;
            emulador = string.Empty;
            whatsapp = 0;
            business = 0;
            habilitado = Habilitatdo;
        }
    }
}
