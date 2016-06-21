using System;
using System.Collections.Generic;
using System.Web.Http;
using ListaTelefonica.API.Extensions.Models;
using ListaTelefonica.API.Models;
using ListaTelefonica.Application;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.API.Controllers
{
    public class OperadoraController : ApiController
    {
        public OperadoraController()
        {
            OperadoraApp = new OperadoraApp();
        }

        private OperadoraApp OperadoraApp;

        // GET: /Operadora      
        public IList<OperadoraModel> Get()
        {
            IList<Operadora> operadoras = OperadoraApp.ObterTodos();

            return operadoras.ToModel();
        }

        // GET: /Operadora/{id}        
        public OperadoraModel Get(Int64 id)
        {
            Operadora operadora = OperadoraApp.ObterPeloId(id);

            return operadora.ToModel();
        }       
        
        // POST: /Operadora
        public void Post(OperadoraModel operadora)
        {
            OperadoraApp.Inserir(operadora.ToDomain());
        }

        public void Put(OperadoraModel operadora)
        {
            OperadoraApp.Atualizar(operadora.ToDomain());
        }

        public void Delete(Int64 id)
        {
            OperadoraApp.Excluir(id);
        }
    }
}
