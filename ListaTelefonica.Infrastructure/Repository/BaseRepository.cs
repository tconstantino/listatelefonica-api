using System;
using System.Collections.Generic;
using System.Linq;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.Infrastructure.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        public BaseRepository(IContextoDB contextoDB)
        {
            ContextoDB = contextoDB;
        }

        protected IContextoDB ContextoDB { get; set; }
        
        protected IQueryable<T> Query { get { return ContextoDB.Query<T>(); } }

        protected IQueryable<T2> GenericQuery<T2>() where T2 : class
        {
            return ContextoDB.Query<T2>();
        }

        public virtual T ObterPeloID(Int64 id)
        {
            return ContextoDB.ObterPelaPK<T>(id);
        }

        public virtual IList<T> ObterTodos()
        {
            return ContextoDB.Query<T>().ToList();
        }

        public virtual void Inserir(T entity)
        {
            ContextoDB.Inserir<T>(entity);
        }

        public virtual void Atualizar(T entity)
        {
            ContextoDB.Atualizar<T>(entity);
        }

        public virtual void Excluir(T entity)
        {
            ContextoDB.Excluir<T>(entity);
        }        
    }
}
