using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using ListaTelefonica.API.Extensions;
using ListaTelefonica.API.Extensions.Models;
using ListaTelefonica.API.Models;
using ListaTelefonica.CrossCuting.Factory;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Extension;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Service.CRUD;
using ListaTelefonica.Domain.Utils;

namespace ListaTelefonica.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ContatoController : ApiController
    {
        private IContatoRepository contatoRepository;
        private ContatoCRUDService contatoCrudService;
        // GET: api/Contato
        public IHttpActionResult Get()
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                contatoRepository = RepositoryFactory.Create<IContatoRepository>(contextoDB);
                IList<Contato> contatos = contatoRepository.ObterTodos();

                if (contatos == null) NotFound();

                return Ok(contatos.ToModel());
            }
        }

        // GET: api/Contato/5
        public IHttpActionResult Get(long id)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                contatoRepository = RepositoryFactory.Create<IContatoRepository>(contextoDB);
                Contato contato = contatoRepository.ObterPeloID(id);
                contatoCrudService = new ContatoCRUDService();

                IList<Message> mensagens = contatoCrudService.Inserir(contato, contatoRepository, contextoDB);


                if (mensagens.HasError()) return NotFound();

                return Ok(contato.ToModel());
            }
        }

        // POST: api/Contato
        public IHttpActionResult Post(ContatoModel contato)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                Contato contatoDomain = contato.ToDomain();
                contatoRepository = RepositoryFactory.Create<IContatoRepository>(contextoDB);
                IOperadoraRepository operadorarepository = RepositoryFactory.Create<IOperadoraRepository>(contextoDB);

                contatoDomain.Telefone.Operadora = operadorarepository.ObterPeloID(contatoDomain.Telefone.Operadora.Identificador);

                contatoCrudService = new ContatoCRUDService();

                IList<Message> mensagens = contatoCrudService.Inserir(contatoDomain, contatoRepository, contextoDB);


                if (mensagens.HasError()) return BadRequest(mensagens.ToJSON());

                String location = string.Concat(this.Url.Request.RequestUri, "/", contatoDomain.Identificador);

                return Created(location, new { obj = contatoDomain.ToModel(), msg = mensagens });
            }
        }

        // PUT: api/Contato/5
        public IHttpActionResult Put(ContatoModel contato)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                Contato contatoDomain = contato.ToDomain();
                contatoCrudService = new ContatoCRUDService();

                IList<Message> mensagens = contatoCrudService.Atualizar(contatoDomain, contatoRepository, contextoDB);

                if (mensagens.HasError()) return BadRequest(mensagens.ToJSON());

                return Ok(mensagens.ToJSON());
            }
        }
               
        // DELETE: api/Contato?id=5
        public IHttpActionResult Delete([FromUri] int[] ids)
        {
            if (ids == null || ids.Length == 0) return NotFound();

            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                contatoRepository = RepositoryFactory.Create<IContatoRepository>(contextoDB);

                IList<Contato> contatos = new List<Contato>();
                //int[] ids = new int[10];
                foreach (int id in ids)
                {
                    contatos.Add(contatoRepository.ObterPeloID(id));
                }
                                
                contatoCrudService = new ContatoCRUDService();

                IList<Message> mensagens = contatoCrudService.Excluir(contatos, contatoRepository, contextoDB);

                if (mensagens.HasError()) return BadRequest(mensagens.ToJSON());

                return Ok(mensagens.ToJSON());
            }
        }
    }
}
