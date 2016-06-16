using System.Data.Entity.ModelConfiguration;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.Infrastructure.Mapping
{
    public class OperadoraMapping : EntityTypeConfiguration<Operadora>
    {
        public OperadoraMapping()
        {
            this.ToTable("Operadora");
            this.HasKey(o => o.Identificador);
            this.Property(o => o.Identificador).HasColumnName("Identificador");
            this.Property(o => o.Codigo).HasColumnName("Codigo");
            this.Property(o => o.Nome).HasColumnName("Nome");
            this.Property(o => o.Preco).HasColumnName("Preco");

            //One-To-Many
            this.HasRequired(o => o.Categoria)
                .WithMany(c => c.Operadoras)
                .Map(o => o.MapKey("Categoria_ID"));

            //Many-To-One
            this.HasMany(o => o.Telefones)
                .WithRequired(t => t.Operadora)
                .Map(t => t.MapKey("Operadora_ID"));
        }
    }
}
