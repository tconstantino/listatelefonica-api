﻿using System;

namespace ListaTelefonica.Domain.Entity
{
    public class Contato
    {
        public Int64 Identificador { get; set; }
        public String Nome { get; set; }
        public virtual Telefone Telefone { get; set; }
        public DateTime DataInclusao { get; set; }
        public String Cor { get; set; }
        public String Serial { get; set; }
        public DateTime DataNascimento { get; set; }
        public Int64 CPF { get; set; }
        public Int64 CNPJ { get; set; }
        public Int32 CEP { get; set; }
    }
}
