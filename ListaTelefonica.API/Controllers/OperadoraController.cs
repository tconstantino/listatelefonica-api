using System;
using System.Web.Http;
using System.Web.Mvc;
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
            
        // GET: /Operadora/{id}        
        public Operadora Get(Int64 id)
        {
            var operadoraEncontrada = OperadoraApp.ObterPeloId(id);
            return new Operadora()
            {
                Identificador = operadoraEncontrada.Identificador,
                Nome = operadoraEncontrada.Nome,
                Preco = operadoraEncontrada.Preco
            };
        }       
        
    }
}
