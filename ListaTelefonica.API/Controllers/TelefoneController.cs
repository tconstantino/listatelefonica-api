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
    public class TelefoneController : ApiController
    {
        // GET: api/Telefone
        public HttpResponseMessage Get()
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                ITelefoneRepository repository = RepositoryFactory.Create<ITelefoneRepository>(contextoDB);
                IList<Telefone> telefones = repository.ObterTodos();

                if (telefones == null) return this.NotFoundResponse();

                IList<Message> mensagens = new List<Message>();
                mensagens.Add(new Message(MessageResource.SucessoNaOperacao, StatusMessageEnum.Success));

                return this.OkResponse(mensagens, telefones.ToModel());
            }
        }

        // GET: api/Telefone/5
        public HttpResponseMessage Get(Int64 id)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                ITelefoneRepository repository = RepositoryFactory.Create<ITelefoneRepository>(contextoDB);
                Telefone telefone = repository.ObterPeloID(id);

                if (telefone == null) return this.NotFoundResponse(null, id);

                IList<Message> mensagens = new List<Message>();
                mensagens.Add(new Message(MessageResource.SucessoNaOperacao, StatusMessageEnum.Success));

                return this.OkResponse(mensagens, telefone.ToModel());
            }
        }

        // POST: api/Telefone
        public HttpResponseMessage Post(TelefoneModel telefone)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                Telefone telefoneDomain = telefone.ToDomain();
                ITelefoneRepository repository = RepositoryFactory.Create<ITelefoneRepository>(contextoDB);

                var crudService = new TelefoneCRUDService();

                IList<Message> mensagens = crudService.Inserir(telefoneDomain, repository, contextoDB);

                if (mensagens.HasError()) return this.BadRequestResponse(mensagens, telefone);

                String location = string.Concat(this.Url.Request.RequestUri, "/", telefoneDomain.Identificador);

                return this.CreatedResponse(mensagens, telefoneDomain.ToModel(), location);
            }
        }

        // PUT: api/Telefone/5
        public HttpResponseMessage Put(TelefoneModel telefone)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                Telefone telefoneDomain = telefone.ToDomain();
                ITelefoneRepository repository = RepositoryFactory.Create<ITelefoneRepository>(contextoDB);

                var crudService = new TelefoneCRUDService();

                IList<Message> mensagens = crudService.Atualizar(telefoneDomain, repository, contextoDB);

                if (mensagens.HasError()) return this.BadRequestResponse(mensagens, telefone);

                return this.OkResponse(mensagens, telefoneDomain.ToModel());
            }
        }

        // DELETE: api/Telefone/5
        public HttpResponseMessage Delete([FromUri] int[] ids)
        {
            if (ids == null || ids.Length == 0) return this.NotFoundResponse(null, ids);

            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                var repository = RepositoryFactory.Create<ITelefoneRepository>(contextoDB);

                IList<Telefone> telefones = new List<Telefone>();

                foreach (int id in ids)
                {
                    telefones.Add(repository.ObterPeloID(id));
                }

                if (telefones.Count == 0) return this.NotFoundResponse(null, ids);

                var crudService = new TelefoneCRUDService();

                IList<Message> mensagens = crudService.Excluir(telefones, repository, contextoDB);

                if (mensagens.HasError()) return this.BadRequestResponse(mensagens, ids);

                return this.OkResponse(mensagens, ids);
            }
        }
    }
}
