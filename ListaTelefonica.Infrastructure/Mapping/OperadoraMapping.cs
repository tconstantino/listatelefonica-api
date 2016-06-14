using System.Data.Entity.ModelConfiguration;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.Infrastructure.Mapping
{
    public class OperadoraMapping : EntityTypeConfiguration<Operadora>
    {
        public OperadoraMapping()
        {
            this.ToTable("Operadora");

            this.Property(o => o.OperadoraID).HasColumnName("Identificador");
            this.Property(o => o.Codigo).HasColumnName("Codigo");
            this.Property(o => o.Nome).HasColumnName("Nome");
            this.Property(o => o.Preco).HasColumnName("Preco");
            //this.HasRequired(o => o.Categoria)
            //    .WithMany(c => c.Operadoras);

        }
    }
}
