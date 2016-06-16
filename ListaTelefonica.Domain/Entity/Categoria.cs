using System;
using System.Collections.Generic;

namespace ListaTelefonica.Domain.Entity
{
    public class Categoria
    {
        public Int64 Identificador { get; set; }
        public String Nome { get; set; }  
        public virtual IList<Operadora> Operadoras { get; set; }
    }
}