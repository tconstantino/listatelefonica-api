using System;
using System.Collections.Generic;
using ListaTelefonica.CrossCuting.Factory;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Service.CRUD;

namespace ListaTelefonica.Application
{
    public class ContatoApp
    {
        public IList<Contato> ObterTodos()
        {
            IContextoDB contextoDB = ContextFactory.DefaultContext;
            IContatoRepository repository = RepositoryFactory.Create<IContatoRepository>(contextoDB);
            return repository.ObterTodos();
        }

        public Contato ObterPeloId(Int64 id)
        {
            IContextoDB contextoDB = ContextFactory.DefaultContext;
            IContatoRepository repository = RepositoryFactory.Create<IContatoRepository>(contextoDB);
            return repository.ObterPeloID(id);
        }

        public void Inserir(Contato contato)
        {
            IContextoDB contextoDB = ContextFactory.DefaultContext;
            IContatoRepository repository = RepositoryFactory.Create<IContatoRepository>(contextoDB);
            var op = RepositoryFactory.Create<IOperadoraRepository>(contextoDB).ObterPeloID(contato.Telefone.Operadora.Identificador);
            contato.Telefone.Operadora = op;

            ContatoCRUDService crudService = new ContatoCRUDService();
            crudService.Inserir(contato, repository, contextoDB);            
        }

        public void Atualizar(Contato contato)
        {
            IContextoDB contextoDB = ContextFactory.DefaultContext;
            IContatoRepository repository = RepositoryFactory.Create<IContatoRepository>(contextoDB);

            ContatoCRUDService crudService = new ContatoCRUDService();
            crudService.Atualizar(contato, repository, contextoDB);
        }

        public void Excluir(Int64 idContato)
        {
            IContextoDB contextoDB = ContextFactory.DefaultContext;
            IContatoRepository repository = RepositoryFactory.Create<IContatoRepository>(contextoDB);
            
            Contato contato = repository.ObterPeloID(idContato);
                        
            ContatoCRUDService crudService = new ContatoCRUDService();
            crudService.Excluir(contato, repository, contextoDB);
            
        }
    }
}
