using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Controlle_de_Senha.Models
{
    public class Controlle_de_SenhaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Controlle_de_SenhaContext() : base("name=Controlle_de_SenhaContext")
        {
        }

        public System.Data.Entity.DbSet<Controlle_de_Senha.Models.Password> Password { get; set; }

        public System.Data.Entity.DbSet<Controlle_de_Senha.Models.HistoricoSenha> HistoricoSenhas { get; set; }
    }
}
