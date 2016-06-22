using System;
using System.Collections.Generic;
using System.Linq;
using ListaTelefonica.CrossCuting.Factory;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Service.CRUD;

namespace ListaTelefonica.Application
{
    public class OperadoraApp
    {
        public IList<Operadora> ObterTodos()
        {
            IContextoDB context = ContextFactory.Create<IContextoDB>();

            var operadoraRepository = RepositoryFactory.Create<IOperadoraRepository>(context);
            return operadoraRepository.ObterTodos();
        }

        public Operadora ObterPeloId(Int64 id)
        {
            IContextoDB context = ContextFactory.Create<IContextoDB>();

            var operadoraRepository = RepositoryFactory.Create<IOperadoraRepository>(context);
            return operadoraRepository.ObterPeloID(id);
        }

        public void Inserir(Operadora operadora)
        {
            IContextoDB context = ContextFactory.Create<IContextoDB>();

            var operadoraRepository = RepositoryFactory.Create<IOperadoraRepository>(context);
            OperadoraCRUDService crudService = new OperadoraCRUDService();

            crudService.Inserir(operadora, operadoraRepository, context);
        }

        public void Atualizar(Operadora operadora)
        {
            IContextoDB context = ContextFactory.Create<IContextoDB>();

            var operadoraRepository = RepositoryFactory.Create<IOperadoraRepository>(context);
            OperadoraCRUDService crudService = new OperadoraCRUDService();

            crudService.Atualizar(operadora, operadoraRepository, context);
        }

        public void Excluir(Int64 idOperadora)
        {
            IContextoDB context = ContextFactory.Create<IContextoDB>();

            var operadoraRepository = RepositoryFactory.Create<IOperadoraRepository>(context);
            Operadora operadora = operadoraRepository.ObterPeloID(idOperadora);

            OperadoraCRUDService crudService = new OperadoraCRUDService();

            crudService.Excluir(operadora, operadoraRepository, context);
        }
    }
}
