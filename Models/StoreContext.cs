using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja.Models
{
    public class StoreContext:DbContext
    {
        //cria a tabela
        public DbSet<Product> Products { get; set; }//nome da tabela Products



    }
}