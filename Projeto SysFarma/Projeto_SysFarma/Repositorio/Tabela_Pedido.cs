//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rep
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tabela_Pedido
    {
        public Tabela_Pedido()
        {
            this.tbl_Produto = new HashSet<Produto>();
        }
    
        public int numero { get; set; }
        public Nullable<decimal> valor { get; set; }
        public int id_Cliente { get; set; }
        public System.DateTime data { get; set; }
    
        public virtual Cliente tbl_Cliente { get; set; }
        public virtual ICollection<Produto> tbl_Produto { get; set; }
    }
}