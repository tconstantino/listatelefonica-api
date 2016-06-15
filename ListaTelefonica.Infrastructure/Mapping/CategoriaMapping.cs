﻿using System.Data.Entity.ModelConfiguration;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.Infrastructure.Mapping
{
    public class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapping()
        {
            this.ToTable("Categoria");
            this.HasKey(c => c.CategoriaID);
            this.Property(c => c.CategoriaID).HasColumnName("Identificador");
            this.Property(c => c.Nome).HasColumnName("Nome");
            this.HasMany(c => c.Operadoras)
                .WithRequired(o => o.Categoria)                
                .Map(o => o.MapKey("Categoria_ID"));
        }
    }
}
