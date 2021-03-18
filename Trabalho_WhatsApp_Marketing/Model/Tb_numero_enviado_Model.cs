using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp_Marketing.Model
{
    public class Tb_numero_enviado_Model
    {
        public int id { get; set; }
        public string telefone { get; set; }
        public Tb_numero_enviado_Model()
        {
            id = 0;
            telefone = string.Empty;
        }
        public Tb_numero_enviado_Model(string telefoneLocal)
        {
            id = 0;
            telefone = telefoneLocal;
        }
    }
}
