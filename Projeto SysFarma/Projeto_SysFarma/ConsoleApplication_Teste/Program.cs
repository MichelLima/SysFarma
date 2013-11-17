using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rep;

namespace ConsoleApplication_Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Repositorio repositorio = new Repositorio();

          
            Cliente cliente = new Cliente();
           
           cliente.nome = "Maria da Penha ";
            cliente.cpf = "00000000000";
            repositorio.InserirCliente(cliente);


             
            
        }
    }
}
