using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacao_Asp.Models
{
    public class Cliente_Endereco: Cliente
     {
         public int id { get; set; }
         public Cliente id_Cliente { get; set; }
         public String rua  { get; set; }
         public int numero { get; set; }
         public String complemento { get; set; }
         public String cep { get; set; }
         public String bairro { get; set; }
         public String cidade { get; set; }
         public String estado { get; set; }
    }
}