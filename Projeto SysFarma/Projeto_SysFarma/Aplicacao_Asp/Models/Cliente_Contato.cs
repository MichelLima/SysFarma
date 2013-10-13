using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacao_Asp.Models
{
    public class Cliente_Contato:Cliente
    {
        public int id{ get; set; }
        public String telefone { get; set; }
        public String email { get; set; }
    }
}