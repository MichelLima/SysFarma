using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysFarma_Asp.Models
{
    public class ContatoCliente
    {
        public int id { get; set; }
        public String telefone { get; set; }
        public Cliente id_cliente { get; set; } 
        public String email { get; set; }
    }
}