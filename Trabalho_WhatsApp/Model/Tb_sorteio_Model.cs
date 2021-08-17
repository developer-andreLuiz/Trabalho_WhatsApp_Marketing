using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp.Model
{
    class Tb_sorteio_Model
    {
        public int id { get; set; }
        public string telefone { get; set; }
        public Tb_sorteio_Model()
        {
            id = 0;
            telefone = string.Empty;
        }
    }
}
