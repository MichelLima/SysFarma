using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SysFarma_Asp.Models
{
    public class ContatoCliente
    {
        public int id { get; set; }
        public String telefone { get; set; }
        public Cliente id_cliente { get; set; }
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public String email { get; set; }
    }
}