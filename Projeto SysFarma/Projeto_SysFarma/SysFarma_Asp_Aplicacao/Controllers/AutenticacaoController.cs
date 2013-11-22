using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SysFarma_Asp_Aplicacao;
using Rep;

namespace SysFarma_Asp_Aplicacao.Controllers
{
    public class AutenticacaoController : Controller
    {
        private bd_SysFarmaEntities bd = new bd_SysFarmaEntities();
        //
        // GET: /Autenticacao/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Cliente model)
        {
            Cliente cliente = null;

            if (model != null && !string.IsNullOrEmpty(model.login)
                && !string.IsNullOrEmpty(model.Senha))
            {
                cliente =
                    (from c in bd.Cliente
                     where
                     c.login != null && c.login == model.login &&
                     c.Senha != null && c.Senha == model.Senha
                     select c)
                     .FirstOrDefault();
            }

            if (cliente != null)
            {
                //Variável de sessão
                SessaoUsuario.UsuarioLogado = cliente;
                return RedirectToAction("Index", "Home", new { nome = cliente.nome});
            }

            return RedirectToAction("Login");
        }

        public ActionResult LogOut()
        {
            SessaoUsuario.UsuarioLogado = null;
            return RedirectToAction("Index","Home");
        
        }

    }
   
}
