using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp_Marketing.Model
{
    class Tb_emulador_Model
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string numero_whatsapp { get; set; }
        public string numero_whatsapp_business { get; set; }
        public string udid { get; set; }
        public int habilitado { get; set; }
        public Tb_emulador_Model()
        {
            id = 0;
            nome = string.Empty;
            numero_whatsapp = string.Empty;
            numero_whatsapp_business = string.Empty;
            udid = string.Empty;
            habilitado = 0;
        }
    }
}
