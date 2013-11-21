using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace Rep
{
    public class Repositorio
    {
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Metodos Referente a Classe Cliente<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public int InserirCliente(Cliente cliente)
        {

            using (bd_SysFarmaEntities db_Context = new bd_SysFarmaEntities())
            {
                    
                db_Context.Entry(cliente).State = EntityState.Added;
                db_Context.SaveChanges();
            }
            return cliente.id_Cliente;
        }

        public void AlterarCliente(Cliente cliente)
        {

            using (bd_SysFarmaEntities db_context = new bd_SysFarmaEntities())
            {

                db_context.Entry(cliente).State = EntityState.Modified;
                db_context.SaveChanges();
            }
        }
        public void RemoverCliente(int id)
        {

            using (bd_SysFarmaEntities bd_context = new bd_SysFarmaEntities())
            {

                Cliente cliente = new Cliente();
                cliente.id_Cliente = id; 
                bd_context.Entry(cliente).State = EntityState.Deleted;
                bd_context.SaveChanges();

            }
        }

        public Cliente GetCliente(int id_cliente)
        {
            Cliente cliente = null;
            using (bd_SysFarmaEntities bd_context = new bd_SysFarmaEntities())
            {

                cliente = (from u in bd_context.Cliente.Include("Pedido")
                           where u.id_Cliente == id_cliente
                           select u).FirstOrDefault();
            }
            return cliente;
        }

        public List<Cliente> GetTodosClientes() {

            List<Cliente> clientes = null;

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities()) {

                clientes = (from c in bd_Context.Cliente.Include(cliente => cliente.Cliente_Endereco)
                            select c).ToList();
             }
            return clientes;       
        }

        public Cliente GetEndereço(int id_cliente)
        {

            Cliente cliente = null;
            using (bd_SysFarmaEntities db_Context = new bd_SysFarmaEntities())
            {

                cliente = (from u in db_Context.Cliente.Include("tbl_Endereco")
                           where u.id_Cliente == id_cliente
                           select u).FirstOrDefault();
            }
            return cliente;
        }

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Metodos de Contato <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public int inserirContato(Cliente_Contato contato)
        {

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                bd_Context.Entry(contato).State = EntityState.Added;
                bd_Context.SaveChanges();
            }

            return contato.id;
        }

        public void AlterarContato(Cliente_Contato contato)
        {

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                bd_Context.Entry(contato).State = EntityState.Modified;
                bd_Context.SaveChanges();

            }

        }
        public Cliente_Contato GetContatoporId(int id_Contato)
        {

            Cliente_Contato contato = null;

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                contato = (from u in bd_Context.Cliente_ContatoSet.Include("Cliente")
                           where u.id == id_Contato
                           select u).FirstOrDefault();
            }
            return contato;
        }

        public List<Cliente_Contato> GetTodosContato()
        {

            List<Cliente_Contato> contato = null;

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                contato = (from c in bd_Context.Cliente_ContatoSet
                            select c).ToList();
            }
            return contato;
        }
       
    }
}