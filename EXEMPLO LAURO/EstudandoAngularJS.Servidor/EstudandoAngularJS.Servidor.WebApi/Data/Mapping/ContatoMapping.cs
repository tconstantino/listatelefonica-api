using EstudandoAngularJS.Servidor.WebApi.Models;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace EstudandoAngularJS.Servidor.WebApi.Data.Mapping
{
    public class ContatoMapping : EntityTypeConfiguration<Contato>
    {
        public ContatoMapping()
        {
            ToTable("Contato");

            HasRequired(x => x.Operadora)
                .WithMany(x => x.Contatos)
                .HasForeignKey(x => x.IDOperadora);

            HasRequired(x => x.Operadora)
                .WithMany(x => x.Contatos)
                .HasForeignKey(x => x.IDOperadora);
        }
    }
}
