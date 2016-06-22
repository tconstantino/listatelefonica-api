using System;
using System.Collections.Generic;
using ListaTelefonica.CrossCuting.Factory;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.Application
{
    public class TelefoneApp
    {
        public IList<Telefone> ObterTodos()
        {
            IContextoDB contextoDB = ContextFactory.Create<IContextoDB>();

            ITelefoneRepository repository = RepositoryFactory.Create<ITelefoneRepository>(contextoDB);

            return repository.ObterTodos();
        }

        public Telefone ObterPeloId(Int64 id)
        {
            IContextoDB contextoDB = ContextFactory.Create<IContextoDB>();

            ITelefoneRepository repository = RepositoryFactory.Create<ITelefoneRepository>(contextoDB);
            return repository.ObterPeloID(id);
        }

        public void Inserir()
        {
            IContextoDB contextoDB = ContextFactory.Create<IContextoDB>();

            ITelefoneRepository repository = RepositoryFactory.Create<ITelefoneRepository>(contextoDB);

            repository.ObterTodos();
        }

        public void Atualizar()
        {
            IContextoDB contextoDB = ContextFactory.Create<IContextoDB>();

            ITelefoneRepository repository = RepositoryFactory.Create<ITelefoneRepository>(contextoDB);

            repository.ObterTodos();
        }

        public void Excluir(Int64 idOperadora)
        {
            IContextoDB contextoDB = ContextFactory.Create<IContextoDB>();

            ITelefoneRepository repository = RepositoryFactory.Create<ITelefoneRepository>(contextoDB);
            repository.ObterPeloID(idOperadora);

            repository.ObterTodos();
        }
    }
}
