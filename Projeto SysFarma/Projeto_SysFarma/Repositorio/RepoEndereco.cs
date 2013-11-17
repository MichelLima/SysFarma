using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace Rep
{
    public class RepoEndereco
    {
        public int InserirEndereco(Cliente_Endereco endereco)
        {

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                bd_Context.Entry(endereco).State = EntityState.Added;
                bd_Context.SaveChanges();

            }
            return endereco.id;
        }
        public void AlterarEndereco(Cliente_Endereco endereco)
        {

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                bd_Context.Entry(endereco).State = EntityState.Modified;
                bd_Context.SaveChanges();
            }
        }
        public void RemoverEndereco(int id_endereco)
        {

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                Cliente_Endereco endereco = new Cliente_Endereco();
                endereco.id = id_endereco;

                bd_Context.Entry(endereco).State = EntityState.Deleted;
                bd_Context.SaveChanges();

            }
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

        public List<Cliente_Endereco> GetTodosendereco()
        {

            List<Cliente_Endereco> endereco = null;

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities())
            {

                endereco = (from c in bd_Context.Cliente_EnderecoSet
                            select c).ToList();
            }
            return endereco;
        }


    }
}  
