using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstudandoAngularJS.Servidor.WebApi.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Operadora> Operadoras { get; set; }
    }
}