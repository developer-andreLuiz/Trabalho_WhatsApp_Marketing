using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp_Marketing.Model
{
    class Tb_numero_bloqueado
    {
        public int id { get; set; }
        public string telefone { get; set; }
        public Tb_numero_bloqueado()
        {
            id = 0;
            telefone = string.Empty;
        }
    }
}
