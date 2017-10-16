using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Controlle_de_Senha.Models
{
    public class HistoricoSenha
    {
        public int Id { get; set; }
        public String Senha { get; set; }
        public int Guiche { get; set; }
        public DateTime DateTime { get; set; }
    }
}