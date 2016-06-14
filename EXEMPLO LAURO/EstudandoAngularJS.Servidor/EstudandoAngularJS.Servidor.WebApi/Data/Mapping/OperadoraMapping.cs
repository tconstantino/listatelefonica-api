using EstudandoAngularJS.Servidor.WebApi.Models;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace EstudandoAngularJS.Servidor.WebApi.Data.Mapping
{
    public class OperadoraMapping : EntityTypeConfiguration<Operadora>
    {
        public OperadoraMapping()
        {
            ToTable("Operadora");

            HasRequired(x => x.Categoria)
                .WithMany(x => x.Operadoras)
                .HasForeignKey(x => x.IDCategoria);

            HasMany(x => x.Contatos)
                .WithRequired(x => x.Operadora)
                .HasForeignKey(x => x.IDOperadora);
        }
    }
}