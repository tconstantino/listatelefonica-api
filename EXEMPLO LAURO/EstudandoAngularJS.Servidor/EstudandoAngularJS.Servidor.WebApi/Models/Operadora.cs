using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstudandoAngularJS.Servidor.WebApi.Models
{
    public class Operadora
    {
        public int ID { get; set; }
        public int IDCategoria { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public decimal Preco { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}