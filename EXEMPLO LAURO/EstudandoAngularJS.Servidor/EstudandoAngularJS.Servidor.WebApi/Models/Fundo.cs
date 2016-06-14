using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstudandoAngularJS.Servidor.WebApi.Models
{
    public class Fundo
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}