using Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SysFarma_Asp_Aplicacao.Controllers
{
    public class ProdutoController : Controller
    {
        private bd_SysFarmaEntities bd = new bd_SysFarmaEntities();
       
        // GET: /Produto/

        public ActionResult CadastrarProduto()
        {

            return View();

        }
        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                bd.Produto.Add(produto);
                bd.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            return View(produto);

        }

        public ActionResult DeletarProduto(int id = 0)
        {

            Produto produto = bd.Produto.Find(id);
            if (produto == null)
            {

                return HttpNotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("DeletarProduto")]
        public ActionResult ConfirmacaoDeletar(int id)
        {

            Produto produto = bd.Produto.Find(id);
            bd.Produto.Remove(produto);
            bd.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditarProduto(int id = 0)
        {

            Produto Produto = bd.Produto.Find(id);
            if (Produto == null)
            {

                return HttpNotFound();
            }
            return View(Produto);
        }

        [HttpPost]
        public ActionResult EditarProduto(Rep.Produto produto)
        {

            if (ModelState.IsValid)
            {

                bd.Entry(produto).State = EntityState.Modified;
                bd.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(produto);
        }

        public ActionResult ListarProduto(string q, int? numvezes)
        {

            RepositorioProduto repositorio = new RepositorioProduto();

            List<Rep.Produto> clientes = repositorio.GetTodosProduto();

            // Models.ClienteModelList model = new Models.ClienteModelList();

            return View(clientes);

        }

    }
}
