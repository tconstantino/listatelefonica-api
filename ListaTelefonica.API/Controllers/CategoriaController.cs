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
    public class CategoriaController : ApiController
    {
        // GET: api/Categoria
        public HttpResponseMessage Get()
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                ICategoriaRepository repository = RepositoryFactory.Create<ICategoriaRepository>(contextoDB);
                IList<Categoria> categorias = repository.ObterTodos();

                if (categorias == null) return this.NotFoundResponse();

                IList<Message> mensagens = new List<Message>();
                mensagens.Add(new Message(MessageResource.SucessoNaOperacao, StatusMessageEnum.Success));

                return this.OkResponse(mensagens, categorias.ToModel());
            }
        }

        // GET: api/Categoria/5
        public HttpResponseMessage Get(long id)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                ICategoriaRepository repository = RepositoryFactory.Create<ICategoriaRepository>(contextoDB);
                Categoria categoria = repository.ObterPeloID(id);

                if (categoria == null) return this.NotFoundResponse(null, id);

                IList<Message> mensagens = new List<Message>();
                mensagens.Add(new Message(MessageResource.SucessoNaOperacao, StatusMessageEnum.Success));

                return this.OkResponse(mensagens, categoria.ToModel());
            }
        }

        // POST: api/Categoria
        public HttpResponseMessage Post(CategoriaModel categoria)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                Categoria categoriaDomain = categoria.ToDomain();
                ICategoriaRepository repository = RepositoryFactory.Create<ICategoriaRepository>(contextoDB);
                                
                var crudService = new CategoriaCRUDService();

                IList<Message> mensagens = crudService.Inserir(categoriaDomain, repository, contextoDB);
                
                if (mensagens.HasError()) return this.BadRequestResponse(mensagens, categoria);

                String location = string.Concat(this.Url.Request.RequestUri, "/", categoriaDomain.Identificador);

                return this.CreatedResponse(mensagens, categoriaDomain.ToModel(), location);
            }
        }

        // PUT: api/Categoria/5
        public HttpResponseMessage Put(CategoriaModel categoria)
        {
            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                Categoria categoriaDomain = categoria.ToDomain();
                var crudService = new CategoriaCRUDService();
                var repository = RepositoryFactory.Create<ICategoriaRepository>(contextoDB);

                IList<Message> mensagens = crudService.Atualizar(categoriaDomain, repository, contextoDB);

                if (mensagens.HasError()) return this.BadRequestResponse(mensagens, categoria);

                return this.OkResponse(mensagens, categoriaDomain.ToModel());
            }
        }

        // DELETE: api/Categoria/5
        public HttpResponseMessage Delete([FromUri] int[] ids)
        {
            if (ids == null || ids.Length == 0) return this.NotFoundResponse(null, ids);

            using (IContextoDB contextoDB = ContextFactory.Create<IContextoDB>())
            {
                var repository = RepositoryFactory.Create<ICategoriaRepository>(contextoDB);

                IList<Categoria> categorias = new List<Categoria>();

                foreach (int id in ids)
                {
                    categorias.Add(repository.ObterPeloID(id));
                }
                
                var crudService = new CategoriaCRUDService();
                
                IList<Message> mensagens = crudService.Excluir(categorias, repository, contextoDB);

                if (mensagens.HasError()) return this.BadRequestResponse(mensagens, ids);

                return this.OkResponse(mensagens, ids);
            }
        }
    }
}
