using System.Collections.Generic;

namespace ListaTelefonica.Domain.Repository
{
    public interface IRepository<T> where T : class
    {
        IList<T> ObterTodos();
        T ObterPeloID();
        void Inserir();
        void Editar();
        void Excluir();
    }
}
