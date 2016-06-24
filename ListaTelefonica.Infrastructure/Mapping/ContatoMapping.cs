﻿using System.Data.Entity.ModelConfiguration;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.Infrastructure.Mapping
{
    public class ContatoMapping : EntityTypeConfiguration<Contato>
    {
        public ContatoMapping()
        {
            this.ToTable("Contato");
            this.HasKey(c => c.Identificador);
            this.Property(c => c.Identificador).HasColumnName("Identificador");
            this.Property(c => c.Nome).HasColumnName("Nome");
            this.Property(c => c.Cor).HasColumnName("Cor");
            this.Property(c => c.DataInclusao).HasColumnName("DataInclusao");

            this.HasOptional(c => c.Telefone)
                .WithOptionalDependent(t => t.Contato)
                .Map(c => c.MapKey("Telefone_ID"));
        }
    }
}
