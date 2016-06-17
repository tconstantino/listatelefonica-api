using System.Collections.Generic;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.Domain.Service
{
    public class TesteService
    {
        public IList<Operadora> BuscarOperadoras(IContextoDB conxteto, IOperadoraRepository repository)
        {
            using(conxteto)
            {
                return repository.ObterTodos();
            }
        }
    }
}
