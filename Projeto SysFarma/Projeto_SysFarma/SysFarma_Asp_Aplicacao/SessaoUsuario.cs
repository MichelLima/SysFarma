using Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysFarma_Asp_Aplicacao
{
    public class SessaoUsuario
    {
        public static Cliente UsuarioLogado{

            get 
            {
                return (Cliente)HttpContext.Current.Session["UsuarioLogado"];            
            }

            set
            {
                HttpContext.Current.Session["UsuarioLogado"] = value;
            }
        
        
        
        }
    }
}