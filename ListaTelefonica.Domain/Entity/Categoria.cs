using System;
using System.Collections.Generic;

namespace ListaTelefonica.Domain.Entity
{
    public class Categoria
    {
        public Int64 CategoriaID { get; set; }
        public String Nome { get; set; }  
        public IList<Operadora> Operadoras { get; set; }
    }
}