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
    public class ContatoController : ApiController
    {
        private IContatoRepository contatoRepository;
        private ContatoCRUDService contatoCrudService;
        // GET: api/Contato
        public HttpResponseMessage Get()
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                contatoRepository = RepositoryFactory.Create<IContatoRepository>(contextoDB);
                IList<Contato> contatos = contatoRepository.ObterTodos();

                if (contatos == null) this.NotFoundResponse();

                IList<Message> mensagens = new List<Message>();
                mensagens.Add(new Message(MessageResource.SucessoNaOperacao, StatusMessageEnum.Success));

                return this.OkResponse(mensagens, contatos.ToModel());
            }
        }

        // GET: api/Contato/5
        public HttpResponseMessage Get(long id)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                contatoRepository = RepositoryFactory.Create<IContatoRepository>(contextoDB);
                Contato contato = contatoRepository.ObterPeloID(id);

                if (contato == null) return this.NotFoundResponse(null, id);

                IList<Message> mensagens = new List<Message>();
                mensagens.Add(new Message(MessageResource.SucessoNaOperacao, StatusMessageEnum.Success));

                return this.OkResponse(mensagens, contato.ToModel());
            }
        }

        // POST: api/Contato
        public HttpResponseMessage Post(ContatoModel contato)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                Contato contatoDomain = contato.ToDomain();
                contatoRepository = RepositoryFactory.Create<IContatoRepository>(contextoDB);
                IOperadoraRepository operadorarepository = RepositoryFactory.Create<IOperadoraRepository>(contextoDB);

                contatoDomain.Telefone.Operadora = null;
                if (contato.Telefone.Operadora != null)
                {
                    contatoDomain.Telefone.Operadora = operadorarepository.ObterPeloID(contato.Telefone.Operadora.Identificador);
                }

                contatoCrudService = new ContatoCRUDService();

                IList<Message> mensagens = contatoCrudService.Inserir(contatoDomain, contatoRepository, contextoDB);


                if (mensagens.HasError()) return this.BadRequestResponse(mensagens, contato);

                String location = string.Concat(this.Url.Request.RequestUri, "/", contatoDomain.Identificador);

                return this.CreatedResponse(mensagens, contatoDomain.ToModel(), location);
            }
        }

        // PUT: api/Contato/5
        public HttpResponseMessage Put(ContatoModel contato)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                Contato contatoDomain = contato.ToDomain();
                contatoCrudService = new ContatoCRUDService();

                contatoRepository = RepositoryFactory.Create<IContatoRepository>(contextoDB);

                IList<Message> mensagens = contatoCrudService.Atualizar(contatoDomain, contatoRepository, contextoDB);

                if (mensagens.HasError()) return this.BadRequestResponse(mensagens, contato);

                return this.OkResponse(mensagens, contato);
            }
        }

        // DELETE: api/Contato?id=5
        public HttpResponseMessage Delete([FromUri] int[] ids)
        {
            if (ids == null || ids.Length == 0) return this.NotFoundResponse(null, ids);

            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                contatoRepository = RepositoryFactory.Create<IContatoRepository>(contextoDB);

                IList<Contato> contatos = new List<Contato>();

                foreach (int id in ids)
                {
                    contatos.Add(contatoRepository.ObterPeloID(id));
                }

                contatoCrudService = new ContatoCRUDService();

                IList<Message> mensagens = contatoCrudService.Excluir(contatos, contatoRepository, contextoDB);

                if (mensagens.HasError()) return this.BadRequestResponse(mensagens, ids);

                return this.OkResponse(mensagens, ids);
            }
        }
    }
}
