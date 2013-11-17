using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Rep;



namespace SysFarma_Asp.Controllers
{
    public class ClienteController : Controller
    {
        private bd_SysFarmaEntities bd = new bd_SysFarmaEntities();
                
        //Metodo para postar um formulario
        public ActionResult CadastrarCliente()
        {
            
            return View();
        }
        //Metodo que vai receber formulatio 
        [HttpPost]
        public ActionResult cadastrarCliente(Cliente cliente) {
            
            if (ModelState.IsValid)
            {
                Repositorio repositorio = new Repositorio();
                repositorio.InserirCliente(cliente);
                return RedirectToAction("Index", "Home");
            }

                return View(cliente);
            
        }
        //Metoro TEMPORARIO que vai mostrar o resultado
        public ActionResult Resultado() {

            return View();
        
        }

        public ActionResult DeletarCliente(int id = 0) {

            Cliente cliente = bd.Cliente.Find(id);
            if(cliente == null){

                return HttpNotFound();           
            }

            return View(cliente);
        }

        [HttpPost, ActionName("DeletarCliente")]
        public ActionResult ConfirmacaoDeletar(int id) {

            Cliente cliente = bd.Cliente.Find(id);
            bd.Cliente.Remove(cliente);
            bd.SaveChanges();
            return RedirectToAction("Index", "Home");     
        }

       public ActionResult EditarCliente(int id=0) {

           Cliente cliente = bd.Cliente.Find(id);
           if (cliente == null) {

               return HttpNotFound();
           
           }
           return View(cliente);
                          
        }

       [HttpPost]
       public ActionResult EditarCliente(Cliente cliente) {

           if (ModelState.IsValid) { 
            
               bd.Entry(cliente).State = EntityState.Modified;
               bd.SaveChanges();
               return RedirectToAction("Index","Home");
            }
            return View(cliente);
        }

       public ActionResult ListarCliente(string q, int? numvezes) {

           Repositorio repositorio = new Repositorio();
           
           List<Cliente> clientes = repositorio.GetTodosContato();

          // Models.ClienteModelList model = new Models.ClienteModelList();

          return View(clientes);
                 
       }

        }
}
