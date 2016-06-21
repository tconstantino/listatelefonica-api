using System.Collections.Generic;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Utils;

namespace ListaTelefonica.Domain.Service.CRUD
{
    public abstract class CRUDService<T> where T : class
    {
        public abstract IList<Message> Inserir(T entity, IRepository<T> repository, IContextoDB contextoDB);

        public abstract IList<Message> Atualizar(T entity, IRepository<T> repository, IContextoDB contextoDB);

        public abstract IList<Message> Excluir(T entity, IRepository<T> repository, IContextoDB contextoDB);
    }
}
