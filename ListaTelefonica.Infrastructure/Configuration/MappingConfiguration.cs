using System.Data.Entity;
using ListaTelefonica.Infrastructure.Mapping;

namespace ListaTelefonica.Infrastructure.Configuration
{
    public class MappingConfiguration
    {
        public static void Configurar(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaMapping());
            modelBuilder.Configurations.Add(new ContatoMapping());
            modelBuilder.Configurations.Add(new OperadoraMapping());
            modelBuilder.Configurations.Add(new TelefoneMapping());
        }
    }
}
