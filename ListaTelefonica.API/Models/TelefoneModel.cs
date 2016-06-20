using System;

namespace ListaTelefonica.API.Models
{
    public class TelefoneModel
    {
        public Int64 Identificador { get; set; }
        public Int64 Numero { get; set; }
        public OperadoraModel Operadora { get; set; }
    }
}