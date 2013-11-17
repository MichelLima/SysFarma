using SysFarma_Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rep;
using System.Data.Entity;
using System.Web.Routing;

namespace SysFarma_Asp_Aplicacao.Controllers
{
    public class EnderecoController : Controller
    {
        //
        // GET: /Endereco/

        private bd_SysFarmaEntities bd = new bd_SysFarmaEntities();

        public ActionResult CadastroEndereco(int idCliente)
        {
            ViewBag.idCliente = idCliente;
            return View();
        }

        [HttpPost]
        public ActionResult CadastroEndereco(Cliente_Endereco endereco, int idclienteInserido)
        {
            if (ModelState.IsValid) {

                endereco.id_Cliente = idclienteInserido;
                bd.Cliente_EnderecoSet.Add(endereco);
                bd.SaveChanges();
                return RedirectToAction("CadastrarContato", "Contato", new { idCliente = endereco.id_Cliente });
            }
            return View(endereco);
      
        }

        public ActionResult AlterarEndereco(int id) {
            
            Cliente_Endereco endereco = bd.Cliente_EnderecoSet.Find(id);
            
            ViewBag.idCliente = endereco.id_Cliente;
            if (endereco == null) {

                return HttpNotFound();           
            }
            return View(endereco);        
        }

        [HttpPost]
        public ActionResult AlterarEndereco(Cliente_Endereco endereco, int idClienteIserido) {

            if (ModelState.IsValid) {
                endereco.id_Cliente = idClienteIserido;
                RepoEndereco repositorio = new RepoEndereco();
                repositorio.AlterarEndereco(endereco);
                bd.SaveChanges();
                return RedirectToAction("Index", "Home");         
            }
            return View(endereco);               
        }

        public ActionResult ListarEndereco(string q, int? numvezes)
        {

            RepoEndereco repoEndereco = new RepoEndereco();

            List<Cliente_Endereco> Endereco = repoEndereco.GetTodosendereco();

            // Models.ClienteModelList model = new Models.ClienteModelList();

            return View(Endereco);

        }

        public ActionResult Deletarendereco(int id = 0)
        {

            Cliente_Endereco endereco = bd.Cliente_EnderecoSet.Find(id);
            Cliente_Endereco idcliente = new Cliente_Endereco();
            ViewBag.idCliente = idcliente.id_Cliente;

            if (endereco == null)
            {

                return HttpNotFound();
            }

            return View(endereco);
        }

        [HttpPost, ActionName("DeletarEndereco")]
        public ActionResult ConfirmacaoDeletar(int id, int idClienteInserido)
        {
            
            Cliente_Endereco endereco = bd.Cliente_EnderecoSet.Find(id);
            Cliente_Endereco idCliente = bd.Cliente_EnderecoSet.Find(idClienteInserido);
           
            bd.Cliente_EnderecoSet.Remove(endereco);
            bd.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


          protected override void OnActionExecuting(ActionExecutingContext filterContext)
                {
                    //Se ele não estiver autenticado E não estiver abrindo a página de login, redirecione para a página Login

                    if (SessaoUsuario.UsuarioLogado == null &&
                        filterContext.ActionDescriptor.ActionName != "Login")
                    {
                
                        filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary { { "controller", "Autenticacao" }, { "action", "Login" } });

                        this.TempData["loginObrigatorio"] = "Você precisa estar autenticado para continuar";
                    }

                    base.OnActionExecuting(filterContext);
                }
            }
    }

