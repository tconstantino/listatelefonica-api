using EstudandoAngularJS.Servidor.WebApi.Models;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace EstudandoAngularJS.Servidor.WebApi.Data.Mapping
{
    public class FundoMapping : EntityTypeConfiguration<Fundo>
    {
        public FundoMapping()
        {
            ToTable("Fundo");

            HasMany(x => x.Contatos)
                .WithRequired(x => x.Fundo)
                .HasForeignKey(x => x.IDFundo);
        }
    }
}