using EstudandoAngularJS.Servidor.WebApi.Data.Repositorio;
using System.Web.Http;
using System.Linq;
using System;
using EstudandoAngularJS.Servidor.WebApi.Models;
using System.Web.Http.Cors;
using System.Collections.Generic;

namespace EstudandoAngularJS.Servidor.WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ContatosController : ApiController
    {
        private readonly ContatoRepositorio _contatoRepositorio;
        public ContatosController()
        {
            _contatoRepositorio = new ContatoRepositorio();
        }
        public IHttpActionResult Get()
        {
            try
            {
                var contatos = _contatoRepositorio.GetAll().ToList();
                return Ok(contatos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Post(Contato contato)
        {
            try
            {
                _contatoRepositorio.Salvar(this.OrganizaContato(contato));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete([FromUri]string[] ids)
        {
            try
            {
                //_contatoRepositorio.Remove(contatos.ToList());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #region Métodos Privados
        private Contato OrganizaContato(Contato contato)
        {
            return new Contato()
            {
                Nome = contato.Nome,
                DataCadastro = DateTime.Now,
                Telefone = contato.Telefone,
                IDFundo = contato.Fundo.ID,
                IDOperadora = contato.Operadora.ID
            };
        }

        #endregion

        
    }
}
