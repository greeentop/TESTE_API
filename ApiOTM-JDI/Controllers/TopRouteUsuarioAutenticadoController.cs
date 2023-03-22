using ApiOTM.Models;
using LibraryEntityData;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ApiOTM.Controllers
{

    [RoutePrefix("api")]
    public class TopRouteUsuarioAutenticadoController : ApiController
    {
        private readonly IRoteirizacaoRepositorio _troteirizacaoRepositorio;

        public TopRouteUsuarioAutenticadoController()
        {
            _troteirizacaoRepositorio = new RoteirizacaoRepositorio();
        }


        [HttpGet]
        [Route("get/login/{login}")]
        public TopRouteUsuario getUsuarioAutenticados(string  login)
        {
            var usuario = _troteirizacaoRepositorio.getTopRouteUsuarioAutenticado(login);

            if (usuario == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return usuario;
        }
    }
}
