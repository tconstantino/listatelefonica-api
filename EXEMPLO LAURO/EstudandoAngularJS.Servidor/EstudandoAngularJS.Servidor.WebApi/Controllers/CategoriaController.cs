using EstudandoAngularJS.Servidor.WebApi.Data.Repositorio;
using System.Web.Http;
using System.Linq;
using System;
using System.Web.Http.Cors;

namespace EstudandoAngularJS.Servidor.WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CategoriaController : ApiController
    {
        private readonly CategoriaRepositorio _categoriaRepositorio;
        public CategoriaController()
        {
            _categoriaRepositorio = new CategoriaRepositorio();
        }
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_categoriaRepositorio.GetAll().ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
