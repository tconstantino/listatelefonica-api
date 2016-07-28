using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ListaTelefonica.API.Extensions;
using ListaTelefonica.API.Extensions.Models;
using ListaTelefonica.API.Models;
using ListaTelefonica.CrossCuting.Factory;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Extension;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Resource;
using ListaTelefonica.Domain.Service.CRUD;
using ListaTelefonica.Domain.Utils;
using ListaTelefonica.Domain.Utils.UtilsEnum;

namespace ListaTelefonica.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class OperadoraController : ApiController
    {        
        // GET: /Operadora      
        public HttpResponseMessage Get()
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                IOperadoraRepository repository = RepositoryFactory.Create<IOperadoraRepository>(contextoDB);
                IList<Operadora> operadoras = repository.ObterTodos();

                if (operadoras == null) return this.NotFoundResponse();

                IList<Message> mensagens = new List<Message>();
                mensagens.Add(new Message(MessageResource.SucessoNaOperacao, StatusMessageEnum.Success));

                return this.OkResponse(mensagens, operadoras.ToModel());
            }
        }

        // GET: /Operadora/{id}        
        public HttpResponseMessage Get(long id)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                IOperadoraRepository repository = RepositoryFactory.Create<IOperadoraRepository>(contextoDB);
                Operadora operadora = repository.ObterPeloID(id);

                if(operadora == null) return this.NotFoundResponse(null, id);

                IList<Message> mensagens = new List<Message>();
                mensagens.Add(new Message(MessageResource.SucessoNaOperacao, StatusMessageEnum.Success));

                return this.OkResponse(mensagens, operadora.ToModel());
            }
        }

        // POST: /Operadora
        public HttpResponseMessage Post(OperadoraModel operadora)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                Operadora operadoraDomain = operadora.ToDomain();
                IOperadoraRepository repository = RepositoryFactory.Create<IOperadoraRepository>(contextoDB);

                var crudService = new OperadoraCRUDService();

                IList<Message> mensagens = crudService.Inserir(operadoraDomain, repository, contextoDB);
                
                if (mensagens.HasError()) return this.BadRequestResponse(mensagens, operadora);

                String location = string.Concat(this.Url.Request.RequestUri, "/", operadoraDomain.Identificador);

                return this.CreatedResponse(mensagens, operadoraDomain.ToModel(), location);
            }
        }

        public HttpResponseMessage Put(OperadoraModel operadora)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                Operadora operadoraDomain = operadora.ToDomain();
                var crudService = new OperadoraCRUDService();
                var repository = RepositoryFactory.Create<IOperadoraRepository>(contextoDB);

                IList<Message> mensagens = crudService.Atualizar(operadoraDomain, repository, contextoDB);

                if (mensagens.HasError()) return this.BadRequestResponse(mensagens, operadora);

                return this.OkResponse(mensagens, operadoraDomain.ToModel());
            }
        }

        // DELETE: api/Operadora/5
        public HttpResponseMessage Delete([FromUri] int[] ids)
        {
            if (ids == null || ids.Length == 0) return this.NotFoundResponse(null, ids);

            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                var repository = RepositoryFactory.Create<IOperadoraRepository>(contextoDB);

                IList<Operadora> operadoras = new List<Operadora>();

                foreach (int id in ids)
                {
                    operadoras.Add(repository.ObterPeloID(id));
                }

                if (operadoras.Count == 0) return this.NotFoundResponse(null, ids);

                var crudService = new OperadoraCRUDService();

                IList<Message> mensagens = crudService.Excluir(operadoras, repository, contextoDB);

                if (mensagens.HasError()) return this.BadRequestResponse(mensagens, ids);

                return this.OkResponse(mensagens, ids);
            }
        }
    }
}
