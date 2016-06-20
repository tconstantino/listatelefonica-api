using System;

namespace ListaTelefonica.API.Models
{
    public class OperadoraModel
    {
        public Int64 Identificador { get; set; }
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }
        public CategoriaModel Categoria { get; set; }
        public Decimal Preco { get; set; }
    }
}