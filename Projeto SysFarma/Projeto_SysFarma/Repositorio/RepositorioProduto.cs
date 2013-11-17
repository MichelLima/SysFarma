using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rep
{
    public class RepositorioProduto
    {

          //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Metodos da Classe Produto<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public int InserirProduto(Produto produto)
        {

            using (bd_SysFarmaEntities bd_context = new bd_SysFarmaEntities())
            {

                bd_context.Entry(produto).State = EntityState.Added;
                bd_context.SaveChanges();
            }

            return produto.id;
        }

        public void RemoverProduto(int id_produto)
        {

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                Produto produto = new Produto();
                bd_Context.Entry(produto).State = EntityState.Deleted;
                bd_Context.SaveChanges();
            }
        }
        public void AlterarProduto(Produto produto)
        {

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                bd_Context.Entry(produto).State = EntityState.Modified;
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

        public List<Produto> GetTodosProduto()
        {

            List<Produto> produtos = null;

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                produtos = (from c in bd_Context.Produto
                            select c).ToList();
            }
            return produtos;
        }
    }

    }

