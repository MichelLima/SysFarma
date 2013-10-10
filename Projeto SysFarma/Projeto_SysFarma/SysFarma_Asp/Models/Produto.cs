using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysFarma_Asp.Models
{
    public class Produto
    {
        public int id { get; set; }
        public String nome { get; set; }
        public String marca { get; set; }
        public Decimal preco { get; set; }
        public String tipo { get; set; }
        public String lote { get; set; }
        public String descricao { get; set; }
        public DateTime validade { get; set; }

    }
}