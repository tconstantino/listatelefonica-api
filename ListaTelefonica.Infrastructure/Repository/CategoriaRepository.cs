using System.Linq;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;


namespace ListaTelefonica.Infrastructure.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
       public CategoriaRepository(IContextoDB contextoDB) : base(contextoDB) { }

        public bool CategoriaPossuiOperadoras(long idCategoria)
        {
            return GenericQuery<Operadora>().Where(o => o.Categoria.Identificador == idCategoria).Count() > 0;
        }
    }
}
