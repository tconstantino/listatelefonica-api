using System;
using System.Collections.Generic;
using ListaTelefonica.CrossCuting.Factory;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Service.CRUD;

namespace ListaTelefonica.Application
{
    public class CategoriaApp
    {
        public IList<Categoria> ObterTodas()
        {
            IContextoDB contextoDB = ContextFactory.Create<IContextoDB>();

            ICategoriaRepository repository = RepositoryFactory.Create<ICategoriaRepository>(contextoDB);
            return repository.ObterTodos();
        }

        public Categoria ObterPeloId(Int64 id)
        {
            IContextoDB contextoDB = ContextFactory.Create<IContextoDB>();

            ICategoriaRepository repository = RepositoryFactory.Create<ICategoriaRepository>(contextoDB);
            return repository.ObterPeloID(id);
        }

        public void Inserir(Categoria categoria)
        {
            IContextoDB contextoDB = ContextFactory.Create<IContextoDB>();

            ICategoriaRepository repository = RepositoryFactory.Create<ICategoriaRepository>(contextoDB);

            CategoriaCRUDService crudService = new CategoriaCRUDService();
            crudService.Inserir(categoria, repository, contextoDB);
        }

        public void Atualizar(Categoria categoria)
        {
            IContextoDB contextoDB = ContextFactory.Create<IContextoDB>();

            ICategoriaRepository repository = RepositoryFactory.Create<ICategoriaRepository>(contextoDB);

            CategoriaCRUDService crudService = new CategoriaCRUDService();
            crudService.Atualizar(categoria, repository, contextoDB);
        }

        public void Excluir(Int64 idCategoria)
        {
            IContextoDB contextoDB = ContextFactory.Create<IContextoDB>();

            ICategoriaRepository repository = RepositoryFactory.Create<ICategoriaRepository>(contextoDB);
            Categoria categoria = repository.ObterPeloID(idCategoria);

            CategoriaCRUDService crudService = new CategoriaCRUDService();
            crudService.Excluir(categoria, repository, contextoDB);

        }
    }
}
