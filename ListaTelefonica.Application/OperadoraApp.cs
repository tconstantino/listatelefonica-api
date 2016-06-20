using System;
using System.Linq;
using ListaTelefonica.CrossCuting.Factory;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.Application
{
    public class OperadoraApp
    {
        public Operadora Buscar()
        {
            IContextoDB context = ContextFactory.Create<IContextoDB>();

            var operadoraRepository = RepositoryFactory.Create<IOperadoraRepository>(context);
            return operadoraRepository.ObterTodos().FirstOrDefault();

        }

        public Operadora ObterPeloId(Int64 id)
        {
            IContextoDB context = ContextFactory.Create<IContextoDB>();

            var operadoraRepository = RepositoryFactory.Create<IOperadoraRepository>(context);
            return operadoraRepository.ObterPeloID(id);
        }

        public void Inserir(Operadora operadora)
        {

        }

        public void Atualizar(Operadora operadora)
        {

        }

        public void Excluir(Operadora operadora)
        {

        }
    }
}
