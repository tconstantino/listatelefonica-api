using System;

namespace ListaTelefonica.Domain.Entity
{
    public class Telefone
    {
        public Int64 Identificador { get; set; }
        public Int64 Numero { get; set; }
        public virtual Operadora Operadora { get; set; }        
    }
}