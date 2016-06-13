using System;

namespace ListaTelefonica.Domain.Entity
{
    public class Telefone
    {
        public Int64 TelefoneID { get; set; }
        public Int64 Numero { get; set; }
        public Operadora Operadora { get; set; }
    }
}