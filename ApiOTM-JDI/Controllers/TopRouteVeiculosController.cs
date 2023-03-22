using ApiOTM.Models;
using LibraryEntityData;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiOTM.Controllers
{

    [RoutePrefix("api")]
    public class TopRouteVeiculosController : ApiController
    {


        private readonly IRoteirizacaoRepositorio _troteirizacaoRepositorio;

        public TopRouteVeiculosController()
        {
            _troteirizacaoRepositorio = new RoteirizacaoRepositorio();
        }

        
        [HttpGet]
        [Route("listar/veiculos/{id}")]
        public List<TopRouteVeiculo> get_TopRoutVeiculos(int id)
        {
            var veiculos = _troteirizacaoRepositorio.get_TopRouteVeiculos(id);

            if (veiculos == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return veiculos;
        }

 
        [HttpGet]
        [Route("detalhes/veiculo/{id}/{veiculo}")]
        public TopRouteVeiculo get_TopRouteVeiculo(int id,int veiculo )
        {
            var vei = _troteirizacaoRepositorio.get_TopRouteVeiculo(id, veiculo);

            if (vei == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return vei;
        }



        [HttpGet]
        [Route("detalhe/Itens/veiculo/{id}/{veiculo}")]
        public List<TopRouteDetalheItensVeiculo> getTopRouteDetalhesItensVeiculo(int id, int veiculo)
        {
            var vei = _troteirizacaoRepositorio.getTopRoute_DetalheItensVeiculo(id, veiculo);

            if (vei == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return vei;
        }


        [HttpGet]
        [Route("datahora/consulta/{id}")]
        public HttpResponseMessage GetDataHoraServidor(int id)
        {
            try
            {
                var dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                return Request.CreateResponse(HttpStatusCode.OK, dataHora + " - " + id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        [HttpGet]
        [Route("getTopRouteVeiculo/{veiculo}")]
        public List<TopRouteVeiculo> getTopRouteVeiculos(string veiculo)
        {
            var vei = _troteirizacaoRepositorio.getTopRouteVeiculos(veiculo);
            return vei;
        }

        [HttpPost]
        [Route("AdicionarVeiculos")]
        public HttpResponseMessage AdicionarVeiculos(List<TopRouteVeiculo> Veiculos)
        {
            bool resultado = false;
            try
            {
                var docs = _troteirizacaoRepositorio.AdicionarVeiculos(Veiculos);
                resultado = docs;
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }

}
