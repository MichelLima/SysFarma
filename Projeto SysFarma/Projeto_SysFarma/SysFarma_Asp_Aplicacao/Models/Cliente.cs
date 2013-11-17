using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SysFarma_Asp.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public  Cliente id_cliente { get; set; }

        [Required(ErrorMessage = "O campo nome é Obrigatorio")]
        public String nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é Obrigatorio")]
        public String CPF { get; set; }

        [DataType(DataType.Date)]
        public DateTime dataNascimento { get; set; }

        [Required]
        public String login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String senha { get; set; }
        [Compare("senha", ErrorMessage= "as senhas não comferem")]
        [DataType(DataType.Password)]
        public String confirmarSenha { get; set; }
    }
}