﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Rep;
using SysFarma_Asp_Aplicacao;
using System.Web.Routing;



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
        public ActionResult cadastrarCliente(Cliente cliente)
        {
            
            if (ModelState.IsValid)
            {
                Repositorio repositorio = new Repositorio();
                repositorio.InserirCliente(cliente);
                return RedirectToAction("CadastroEndereco", "endereco", new { idCliente = cliente.id_Cliente });
            }

            return View(cliente);

        }
       
        public ActionResult DeletarCliente(int id = 0)
        {

            Cliente cliente = bd.Cliente.Find(id);
            if (cliente == null)
            {

                return HttpNotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("DeletarCliente")]
        public ActionResult ConfirmacaoDeletar(int id)
        {

            Cliente cliente = bd.Cliente.Find(id);
            bd.Cliente.Remove(cliente);
            bd.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditarCliente(int id = 0)
        {

            Cliente cliente = bd.Cliente.Find(id);
            if (cliente == null)
            {

                return HttpNotFound();

            }
            return View(cliente);

        }

        [HttpPost]
        public ActionResult EditarCliente(Cliente cliente)
        {

            if (ModelState.IsValid)
            {

                bd.Entry(cliente).State = EntityState.Modified;
                bd.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(cliente);
        }

        public ActionResult ListarCliente(string q, int? numvezes)
        {

            Repositorio repositorio = new Repositorio();

            List<Cliente> clientes = repositorio.GetTodosClientes();

           
             // Models.ClienteModelList model = new Models.ClienteModelList();

            return View(clientes);

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

