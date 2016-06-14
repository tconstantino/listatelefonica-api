using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstudandoAngularJS.Servidor.WebApi.Models
{
    public class Contato
    {
        public int ID { get; set; }
        public int IDOperadora { get; set; }
        public int IDFundo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Operadora Operadora { get; set; }
        public virtual Fundo Fundo { get; set; }
    }
}
