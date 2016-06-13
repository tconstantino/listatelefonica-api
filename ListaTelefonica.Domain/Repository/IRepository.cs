using System;
using System.Collections.Generic;

namespace ListaTelefonica.Domain.Repository
{
    public interface IRepository<T> where T : class
    {        
        IList<T> ObterTodos();
        T ObterPeloID(Int64 id);
        void Inserir(T entity);
        void Atualizar(T entity);
        void Excluir(T entity);
    }
}
