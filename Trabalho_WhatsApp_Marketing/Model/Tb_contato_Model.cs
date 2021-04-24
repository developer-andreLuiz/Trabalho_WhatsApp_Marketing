using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp_Marketing.Model
{
    public class Tb_contato_Model
    {
        public int id { get; set; }
        public string telefone { get; set; }
        public string uf { get; set; }
        public string municipio { get; set; }
        public string bairro { get; set; }
        public int habilitado { get; set; }
        public Tb_contato_Model()
        {
            id = 0;
            telefone = string.Empty;
            uf = string.Empty;
            municipio = string.Empty;
            bairro = string.Empty;
            habilitado = 0;
        }
        public Tb_contato_Model(string telefoneLocal)
        {
            id = 0;
            telefone = telefoneLocal;
            uf = string.Empty;
            municipio = string.Empty;
            bairro = string.Empty;
            habilitado = 0;
        }
    }
}
