using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Rep;

namespace SysFarma_Asp_Aplicacao.Controllers
{
    public class ContatoController : Controller
    {
        private bd_SysFarmaEntities bd = new bd_SysFarmaEntities();
        //
        // GET: /Contato/

        public ActionResult CadastrarContato(int idCliente)
        {
            ViewBag.idCliente = idCliente;
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarContato(Cliente_Contato contato, int idClienteInserido)
        {

            if (ModelState.IsValid)
            {
                contato.id_Cliente = idClienteInserido;
                Repositorio repositorio = new Repositorio();
                repositorio.inserirContato(contato);
                return RedirectToAction("Index", "Home");
            }

            return View(contato);

        }

        public ActionResult DeletarContato(int id = 0)
        {

            Cliente_Contato contato = bd.Cliente_ContatoSet.Find(id);
            Cliente_Contato idCliente = new Cliente_Contato();
            ViewBag.id_Cliente = idCliente.id_Cliente;
            if (contato == null)
            {

                return HttpNotFound();
            }

            return View(contato);
        }
        [HttpPost, ActionName("DeletarContato")]
        public ActionResult ConfirmacaoDeletar(int id, int idClienteInserido)
        {

            Cliente_Contato contato = bd.Cliente_ContatoSet.Find(id);
            Cliente_Contato idCliente = bd.Cliente_ContatoSet.Find(idClienteInserido);
            bd.Cliente_ContatoSet.Remove(contato);
            bd.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditarContato(int id )
        {

            Cliente_Contato contato = bd.Cliente_ContatoSet.Find(id);
            ViewBag.idContato = contato.id_Cliente;
            
            if (contato == null)
            {

                return HttpNotFound();

            }
            return View(contato);

        }

        [HttpPost]
        public ActionResult EditarContato(Cliente_Contato contato, int idContatoInerido)
        {

            if (ModelState.IsValid)
            {
                contato.id_Cliente = idContatoInerido;
                Repositorio repositorio = new Repositorio();
                repositorio.AlterarContato(contato);
                bd.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(contato);
        }
        public ActionResult ListarContato(string q, int? numvezes)
        {

            Repositorio repositorio = new Repositorio();

            List<Cliente_Contato> contato = repositorio.GetTodosContato();
            // Models.ClienteModelList model = new Models.ClienteModelList();

            return View(contato);

        }


    }
}
