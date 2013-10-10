using SysFarma_Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysFarma_Asp.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/

        //Metodo para postar um formulario
        public ActionResult CadastrarCliente()
        {
            var cliente = new Cliente();
            return View(cliente);
        }
        //Metodo que vai receber formulatio 
        [HttpPost]
        public ActionResult cadastrarCliente(Cliente cliente) {

            if (ModelState.IsValid) 
            {
                return View("AreaCliente", cliente);
            }

            return View(cliente);
                
        }
        //Metoro TEMPORARIO que vai mostrar o resultado
        public ActionResult Resultado(Cliente cliente) {

            return View(cliente);
        
        }
    }
}
