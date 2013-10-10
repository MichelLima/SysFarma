using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysFarma_Asp.Models
{
    public class ClienteEndereco
    {
        public int id { get; set; }
        public String rua { get; set; }
        public String numero { get; set; }
        public String complemento { get; set; }
        public String cep { get; set; }
        public String bairro { get; set; }
        public String cidade { get; set; }
        public String estado { get; set; }
        public Cliente id_Cliente { get; set; }
    }
}