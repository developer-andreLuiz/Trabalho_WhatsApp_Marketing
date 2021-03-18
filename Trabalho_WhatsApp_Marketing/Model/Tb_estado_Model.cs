using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp_Marketing.Model
{
    class Tb_estado_Model
    {
        public int id { get; set; }
        public string codigo_uf { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public string regiao { get; set; }

        public Tb_estado_Model()
        {
            id = 0;
            codigo_uf = string.Empty;
            nome = string.Empty;
            uf = string.Empty;
            regiao = string.Empty;
        }
    }
}
