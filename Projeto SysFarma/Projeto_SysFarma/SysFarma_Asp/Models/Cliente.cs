﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysFarma_Asp.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public String nome { get; set; }
        public String CPF { get; set; }
        public DateTime dataNascimento { get; set; }
        
    }
}