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
    public class TopRouteItensController : ApiController
    {

        private readonly IRoteirizacaoRepositorio _troteirizacaoRepositorio;

        public TopRouteItensController()
        {
            _troteirizacaoRepositorio = new RoteirizacaoRepositorio();
        }


        #region"GET"

        [HttpGet]
        [Route("login/{login}/{password}")]
        public TopRouteLogin get_UsuariosLogin(string login , string password)
        {
            var usuario = _troteirizacaoRepositorio.get_UsuariosLogin(login, password);
            return usuario;
        }


        [HttpGet]
        [Route("filiaisUsuario/{codUsuario}")]
        public List<TopRouteFiliaisUsuario> get_UsuariosLogin(int codUsuario)
        {
            var Filiaisusuario = _troteirizacaoRepositorio.get_FiliaisUsuario(codUsuario);
            return Filiaisusuario;
        }

        [HttpGet]
        [Route("documentosRoteirizados/{dt_inicio}/{dt_final}")]
        public List<TopRouteDocumentosRoteirizados> get_DocumentoRoteirizados(string dt_inicio, string dt_final)
        {
            var docs_router = _troteirizacaoRepositorio.get_DocumentoRoteirizados(dt_inicio, dt_final);
            return docs_router;
        }











        [HttpGet]
        [Route("pickingList/{cod_roteirizacao}/{cod_filais}/{veiculo}")]
        public TopRoutePickingList get_pickingList(int cod_roteirizacao, int cod_filais ,  string veiculo)
        {

            var docs = _troteirizacaoRepositorio.GetPickingList(cod_roteirizacao, cod_filais, veiculo);

            if (docs == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return docs;
        }


        #region"SERVICOS ITENS COLETA/ENTREGA"

        //[HttpGet]
        //[Route("job/documentoManifesto/{codRoute}/{codFilial}")]
        //public TopRouteJobs getJobManifestosDocumentos(int codRoute, int codFilial)
        //{
        //    var json = _troteirizacaoRepositorio.getJobManifestosDocumentos(codRoute, codFilial);

        //    if (json == null)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        //    }
        //    return json;
        //}


        [HttpGet]
        [Route("listar/rotasDistribuicao/{id}")]
        public List<TopRouteRotasDistribuicao> get_RotasDistibuicao(int id)
        {
            var docs = _troteirizacaoRepositorio.get_RotasDistibuicao(id);

            if (docs == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return docs;
        }

        [HttpGet]
        [Route("detalhes/roteirizacaoItens/{id}")]
        public List<TopRouteItens> getRoteirizacaoItens(int id)
        {
            var docs = _troteirizacaoRepositorio.getRoteirizacaoItens(id);

            if (docs == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return docs;
        }

        [HttpGet]
        [Route("rotasEnviadas/{codRote}/{data}")]
        public List<TopRouteUtil> getrotasEnviadas(int codRote, string data)
        {
            var docs = _troteirizacaoRepositorio.getrotasEnviadas(codRote, data);

            if (docs == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return docs;
        }







        #endregion


        #endregion

        #region"PUT"


        [HttpPut]
        [Route("documentosBaixa")]
        public HttpResponseMessage documento_baixa_routeasy(List<TopRouteDocumentosRoteirizados> documentos)
        {

            bool resultado = false;
            try
            {
                var docs = _troteirizacaoRepositorio.documento_baixa_routeasy(documentos);
                resultado = docs;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpPut]
        [Route("putLimparVeiculogs")]
        public HttpResponseMessage LimparVeiculo(List<TopRouteVeiculo> veiculos)
        {

            bool resultado = false;
            try
            {

                TopRouteVeiculo vei = veiculos[0];

                var docs = _troteirizacaoRepositorio.putLimparVeiculo(vei);
                resultado = docs;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpPut]
        [Route("putRota")]
        public HttpResponseMessage AtualizaRota(List<TopRouteItens> PutRota)
        {

            bool resultado = false;
            try
            {

                var docs = _troteirizacaoRepositorio.putRota(PutRota);
                resultado = docs;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpPut]
        [Route("conferencia/{cod_roteirizacoa}/{cod_rota}/{cod_documento}/{acao}")]
        public HttpResponseMessage Atualizar_Conferencia(int cod_roteirizacoa, int cod_rota , int cod_documento, string acao, string tiporouter)
        {

            bool resultado = false;
            try
            {
                var docs = _troteirizacaoRepositorio.put_Conferencia(cod_roteirizacoa, cod_rota, cod_documento, acao, tiporouter);
                resultado = docs;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpPut]
        [Route("DocumentosFisicoReal")]
        public HttpResponseMessage Atualiza_DocumentoFisicoReal(List<TopRouteItens> itens)
        {

            bool resultado = false;
            try
            {
                var docs = _troteirizacaoRepositorio.put_DocFisicoReal(itens);
                resultado = docs;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpPut]
        [Route("enviarRouteasyIndividual")]
        public HttpResponseMessage enviarRouteasyIndividual(TopRouteIndividual  roteirizacao)
        {

            bool resultado = false;
            try
            {

                var docs = _troteirizacaoRepositorio.postEnviarRouteasy(roteirizacao);
                resultado = docs;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpPut]
        [Route("enviarOTM")]
        public HttpResponseMessage enviarOTM(TopRoute roteirizacao)
        {

            bool resultado = false;
            try
            {

                var docs = _troteirizacaoRepositorio.putEnviarOTM(roteirizacao);
                resultado = docs;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        [HttpPut]
        [Route("naoRoteirizar")]
        public HttpResponseMessage bloqueiaServicoParaNaoRoteirizarOTM(TopRouteItens putNaoRoteirizar)
        {

            bool resultado = false;
            try
            {
                
                var docs = _troteirizacaoRepositorio.putNaoRoteirizar(putNaoRoteirizar);
                resultado = docs;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpPut]
        [Route("servicos")]
        public HttpResponseMessage Put(List<TopRouteItens> servicos)
        {

            bool resultado = false;
            try {

                var docs = _troteirizacaoRepositorio.put(servicos);
                resultado = docs;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);

            }catch (Exception ex){
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }


        [HttpPut]
        [Route("PUT_ROTA_DOC_REAL")]
        public HttpResponseMessage PUT_ROTA_DOC_REAL(List<TopRouteItens> servicos)
        {

            bool resultado = false;
            try
            {

                var docs = _troteirizacaoRepositorio.PUT_ROTA_DOC_REAL(servicos);
                resultado = docs;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }









        [HttpPut]
        [Route("servicos/del")]
        public HttpResponseMessage del(List<TopRouteItens> servicos)
        {

            bool resultado = false;
            try
            {

                var docs = _troteirizacaoRepositorio.del(servicos);
                resultado = docs;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("putSequencia")]
        public HttpResponseMessage putSequencia(List<TopRouteItens> servicos)
        {
            bool resultado = false;
            try
            {

                var docs = _troteirizacaoRepositorio.putSequencia(servicos);
                resultado = docs;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        #endregion

        #region "POST"

       // /// <summary>
       // /// Metodo para cadastrar um novo cliente
       // /// </summary>
       // /// <param name="cliente"></param>
       // /// <returns></returns>
       // [HttpPost]
       // [Route("cliente")]
       // //public HttpResponseMessage salvaCliente([FromBody]object json)
       // //public HttpResponseMessage salvaCliente(cliente cliente)
       // public HttpResponseMessage salvaCliente([FromBody]object json)
       // {
       //     bool resultado = false;
       //     //var docs ;    
       //     try
       //     {


       //         //LibraryEntityData.Routeasy.Model.Retorno.mainRetorno teste  new LibraryEntityData.Routeasy.Model.Retorno.mainRetorno();


       //         var docs = _troteirizacaoRepositorio.salvateste(json);
       //         resultado =  docs;

       //         return Request.CreateResponse(HttpStatusCode.OK, resultado);

       //     }
       //     catch (Exception ex)
       //     {
       //         return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
       //     }
       // }



       //[HttpPut]
       //[Route("atualizarCliente")]
       // public HttpResponseMessage putCliente(cliente cliente)
       // {
       //     bool resultado = false;
       //     try
       //     {

       //         var docs = _troteirizacaoRepositorio.atualizarCliente(cliente);
       //         resultado = docs;

       //         return Request.CreateResponse(HttpStatusCode.OK, resultado);

       //     }
       //     catch (Exception ex)
       //     {
       //         return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
       //     }
       // }


        #endregion







    }
}


