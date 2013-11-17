using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rep
{
    public class RepositorioPedido
    {
        public int InserirPedido(Pedido pedido) {

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities()) {

                bd_Context.Entry(pedido).State = EntityState.Added;
                bd_Context.SaveChanges();            
            }
            return pedido.numero;
        }
        public void AlterarPedido(Pedido pedido) {

            using (bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities()) {

                bd_Context.Entry(pedido).State = EntityState.Modified;
            }
        }
        public void Remover(int numero){
        
            using(bd_SysFarmaEntities bd_Context = new bd_SysFarmaEntities()){
            
               Pedido pedido = new Pedido();
               pedido.numero = numero;
               
                bd_Context.Entry(pedido).State = EntityState.Deleted;
                bd_Context.SaveChanges();
                         
            }
        }
        
        }
        
        }
    
