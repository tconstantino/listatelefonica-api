using EstudandoAngularJS.Servidor.WebApi.Models;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace EstudandoAngularJS.Servidor.WebApi.Data.Mapping
{
    public class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapping()
        {
            ToTable("Categoria");

            HasMany(x => x.Operadoras)
                .WithRequired(x => x.Categoria)
                .HasForeignKey(x => x.IDCategoria);
        }
    }
}