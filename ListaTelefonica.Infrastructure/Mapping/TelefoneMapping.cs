﻿using System.Data.Entity.ModelConfiguration;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.Infrastructure.Mapping
{
    public class TelefoneMapping : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMapping()
        {
            this.ToTable("Telefone");
            this.HasKey(t => t.Identificador);            
            this.Property(t => t.Identificador).HasColumnName("Identificador");
            this.Property(t => t.Numero).HasColumnName("Numero");

            //One-To-One
            this.HasRequired(t => t.Contato)
                .WithOptional(c => c.Telefone)
                .Map(t => t.MapKey("Contato_ID"));

            //Many-To-One
            this.HasRequired(t => t.Operadora)
                .WithMany(o => o.Telefones)
                .Map(t => t.MapKey("Operadora_ID"));
        }
    }
}
