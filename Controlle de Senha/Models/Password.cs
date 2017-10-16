using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controlle_de_Senha.Models
{
    public class Password
    {
        public int Id { get; set; }
        public int NumeroSenha { get; set; }
        public int NumSenhaPreferencial { get; set; }
        public String Tipo { get; set; }
        public IEnumerable<string> TiposDeSenhas { get; set; }
        public bool Preferencial { get; set; }
        public bool ExisteSenhaPreferencial { get; set; }
        public DateTime? DataHora { get; set; }
        public int Guiche { get; set; }
        public List<String> ListaSenhas { get; set; }
    }
}