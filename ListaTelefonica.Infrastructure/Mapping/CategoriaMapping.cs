using System.Data.Entity.ModelConfiguration;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.Infrastructure.Mapping
{
    public class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapping()
        {
            this.ToTable("Categoria");
            this.HasKey(c => c.Identificador);
            this.Property(c => c.Identificador).HasColumnName("Identificador");
            this.Property(c => c.Nome).HasColumnName("Nome");

            //One-To-Many
            this.HasMany(c => c.Operadoras)
                .WithRequired(o => o.Categoria)
                .Map(o => o.MapKey("Categoria_ID"));
        }
    }
}
