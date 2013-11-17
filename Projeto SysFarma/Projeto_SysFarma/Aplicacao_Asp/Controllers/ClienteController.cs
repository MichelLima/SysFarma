using Aplicacao_Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;


namespace Aplicacao_Asp.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/
        

        public ActionResult CadastrarCliente()
        {

            var cliente = new Cliente();
            return View(cliente);
        }

        [HttpPost]
        public ActionResult CadastrarCliente(Cliente cliente){

            if (ModelState.IsValid)
            {
                return View("Resultado", cliente);
            }
            
            return View(cliente);    
    }
        public ActionResult Resultado(Cliente cliente) {

            return View(cliente);
        
        
        }

        public ActionResult EditarCliente(Cliente cliente) { 
        
            Cliente cliente = repositorio.
            
        
        
        
        }
    }
}
