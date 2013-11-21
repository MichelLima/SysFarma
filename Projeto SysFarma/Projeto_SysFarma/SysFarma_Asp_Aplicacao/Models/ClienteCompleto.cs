using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rep;

namespace SysFarma_Asp_Aplicacao.Models
{
    public class ClienteCompleto
    {
       public Cliente cliente = new Cliente();
       public Cliente_Endereco endereco = new Cliente_Endereco();
       public Cliente_Contato contato = new Cliente_Contato();
    }
}