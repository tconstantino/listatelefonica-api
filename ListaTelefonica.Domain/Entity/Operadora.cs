using System;
using System.Collections.Generic;

namespace ListaTelefonica.Domain.Entity
{
    public class Operadora
    {
        public Int64 Identificador { get; set; }
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }
        public virtual Categoria Categoria { get; set; }        
        public Decimal Preco { get; set; }
        public virtual IList<Telefone> Telefones { get; set; }
    }
}
