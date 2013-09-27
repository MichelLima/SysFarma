using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Rep
{
    public class Repositorio
    {
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Metodos Referente a Classe Cliente<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public int InserirCliente(Cliente cliente)
        {

            using ( bd_SysFarmaEntities db_Context = new bd_SysFarmaEntities())
            {

                db_Context.Entry(cliente).State = db_Context.added;
                db_Context.SaveChanges();
            }
            return cliente.id_Cliente;
        }

        public void AlterarCliente(Cliente cliente){

            using (bd_SysFarmaEntities db_context = new bd_SysFarmaEntities())
            {

                db_context.Entry(cliente).State = db_context.Modified();
                db_context.SaveChanges();
            }
        }
        public void RemoverCliente(int id_cliente)
        {

            using (bd_SysFarmaEntities bd_context = new bd_SysFarmaEntities())
            {

                Cliente ciente = new Cliente();
                bd_context.Entry(ciente).State = bd_context.Delete;
                bd_context.SaveChanges();

            }
        }

        public Cliente GetCliente(int id_cliente)
        {
            Cliente cliente = null;
            using (bd_SysFarmaEntities bd_context = new bd_SysFarmaEntities())
            {

                cliente = (from u in bd_context.Cliente.Include("Produto")
                           where u.id_Cliente == id_cliente
                           select u).FirstOrDefault();
            }
            return cliente;
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

                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Metodos da Classe Produto<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public int InserirProduto(Produto produto)
        {

            using (bd_SysFarmaEntities bd_context = new bd_SysFarmaEntities())
            {

                bd_context.Entry(produto).State = bd_context.added;
                bd_context.SaveChanges();
            }

            return produto.id;
        }

        public void RemoverProduto(int id_produto)
        {

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                Produto produto = new Produto();
                bd_Context.Entry(produto).State = bd_Context.Delete;
                bd_Context.SaveChanges();
            }
        }
        public void AlterarProduto(Produto produto)
        {

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                bd_Context.Entry(produto).State = bd_Context.Modified();
                bd_Context.SaveChanges();
            }
        }
        public Produto getProduto(int id_produto){

           Produto produto = null;
           using(bd_SysFarmaEntities bd_context = new bd_SysFarmaEntities()){
           
              produto = (from u in bd_context.Produto
                         where u.id == id_produto
                         select u).FirstOrDefault(); 
           }
           return produto;
       }
    }
    }

