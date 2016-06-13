using System;
using System.Linq;

namespace ListaTelefonica.Domain.Repository
{
    public interface IContextoDB : IDisposable
    {
        void IniciarTransacao();
        void Commit();
        void Rollback();
        IQueryable<T> Query<T>() where T : class;
        void Inserir<T>(T entity) where T : class;
        void Atualizar<T>(T entity) where T : class;
        void Excluir<T>(T entity) where T : class;        
    }
}
