using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicacao_Asp.Models
{
    public class Cliente
    {
        public int id { get; set; }
        [Required(ErrorMessage="Campo nome é Obrigatorio")]
        public String nome { get; set; }
        [Required(ErrorMessage="O Campo CPF é obrigatorio")]
     //  [RegularExpression(@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/", ErrorMessage = "O CPF deve Seguir o modelo 999.999.999-99")]
        public String cpf { get; set; }
        public DateTime dataNascimento { get; set; }
    }
}