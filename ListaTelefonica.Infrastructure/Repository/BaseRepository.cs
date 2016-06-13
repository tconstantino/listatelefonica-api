using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.Infrastructure.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        public BaseRepository(IContextoDB contextoDB)
        {
            ContextoDB = contextoDB;
        }

        private IContextoDB ContextoDB { get; set; }

        private T t { get; }

        public T ObterPeloID(Int64 id)
        {            
            var tipo = t.GetType();
            var prop = tipo.GetRuntimeProperty("Identificador");
            var val = prop.GetValue(t);

            return ContextoDB.Query<T>().Where(t => (Int64)t.GetType().GetRuntimeProperty("Identificador").GetValue(t) == id).FirstOrDefault();
        }

        public IList<T> ObterTodos()
        {
            return ContextoDB.Query<T>().ToList();
        }

        public void Inserir(T entity)
        {
            ContextoDB.Inserir<T>(entity);
        }

        public void Atualizar(T entity)
        {
            ContextoDB.Atualizar<T>(entity);
        }

        public void Excluir(T entity)
        {
            ContextoDB.Excluir<T>(entity);
        }
    }


}
