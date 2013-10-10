using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysFarma_Asp.Models
{
    public class Pedido
    {
        public int numero { get; set; }
        public Decimal valor { get; set; }
        public DateTime data { get; set; }
        public Cliente id_Cliente { get; set; }
    }
}