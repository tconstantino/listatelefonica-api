using EstudandoAngularJS.Servidor.WebApi.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EstudandoAngularJS.Servidor.WebApi.Data.Repositorio
{
    public abstract class BaseRepositorio<T> where T : class
    {
        protected readonly AngularJSContexto _contexto;

        public BaseRepositorio()
        {
            _contexto = new AngularJSContexto();
            _contexto.Configuration.ProxyCreationEnabled = false;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _contexto.Set<T>();
        }

        public void Salvar(T item)
        {
            _contexto.Set<T>().Add(item);
            _contexto.SaveChanges();
        }

        public void Remove(T obj)
        {
            _contexto.Entry(obj).State = EntityState.Deleted;
            _contexto.SaveChanges();
        }

        public void Remove(List<T> objs)
        {
            foreach (var obj in objs)
                _contexto.Entry(obj).State = EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}