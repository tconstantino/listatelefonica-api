using System;

namespace ListaTelefonica.Domain.Entity
{
    public class Operadora
    {
        public Int64 OperadoraID { get; set; }
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }
        public Categoria Categoria { get; set; }        
        public Decimal Preco { get; set; }
    }
}
