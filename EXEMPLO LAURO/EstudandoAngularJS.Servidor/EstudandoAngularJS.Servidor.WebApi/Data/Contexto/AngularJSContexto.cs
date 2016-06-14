using EstudandoAngularJS.Servidor.WebApi.Data.Mapping;
using EstudandoAngularJS.Servidor.WebApi.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace EstudandoAngularJS.Servidor.WebApi.Data.Contexto
{
    public class AngularJSContexto : DbContext
    {
        public AngularJSContexto()
            : base("AngularJSDesenvolvimento")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ContatoMapping());
            modelBuilder.Configurations.Add(new OperadoraMapping());
            modelBuilder.Configurations.Add(new CategoriaMapping());
            modelBuilder.Configurations.Add(new FundoMapping());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Contato> Contato { get; set; }
        public DbSet<Operadora> Operadora { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Fundo> Fundo { get; set; }
    }
}