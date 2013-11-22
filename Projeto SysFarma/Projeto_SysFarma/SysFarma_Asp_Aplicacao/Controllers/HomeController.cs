using Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysFarma_Asp_Aplicacao.Controllers
{
    public class HomeController : Controller
    {
        bd_SysFarmaEntities bd = new bd_SysFarmaEntities();
        //
        // GET: /Home/

        public ActionResult Index(string q, int? numvezes)
        {
            
            RepositorioProduto repositorio = new RepositorioProduto();

            List<Rep.Produto> clientes = repositorio.GetTodosProduto();

            // Models.ClienteModelList model = new Models.ClienteModelList();

            return View(clientes);
        }

        //Metodo para postar um formulario
        public ActionResult CadastrarCliente()
        {

            return View();
        }
        //Metodo que vai receber formulatio 
        [HttpPost]
        public ActionResult cadastrarCliente(Cliente cliente)
        {

            if (ModelState.IsValid)
            {

                Repositorio repositorio = new Repositorio();
                repositorio.InserirCliente(cliente);
                return RedirectToAction("CadastroEndereco", "Endereco", new { idCliente = cliente.id_Cliente });
            }

            return View(cliente);

        }


         }

}
