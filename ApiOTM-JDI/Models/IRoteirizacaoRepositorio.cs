using System.Collections.Generic;
using System.Web.Http;
using LibraryEntityData;

namespace ApiOTM.Models
{
    public interface IRoteirizacaoRepositorio
    {

        IEnumerable<TopRoute> All { get; }
        TopRoute Find(int id);
        TopRoutePickingList Find1(int id, string veiculo);
        List<TopRouteItens> getRoteirizacaoItens(int id);
        List<TopRouteUtil> getrotasEnviadas(int codRote, string data);

        List<TopRouteIntegracaoLogs> getIntegracaoLogs(string id);

        TopRouteDashboard getRoteirizacaoDashboard(int id);

        bool put_DocFisicoReal(List<TopRouteItens> itens);
        bool put_Conferencia(int cod_roteirizacao, int cod_rota, int cod_documento, string acao, string tiporouter);

        bool put(List<TopRouteItens> servico);
        bool PUT_ROTA_DOC_REAL(List<TopRouteItens> servico);
        
        bool del(List<TopRouteItens> servico);

        bool putRota(List<TopRouteItens> putrota);
    
        bool putEnviarOTM(TopRoute  roteirizacao);
        bool postEnviarRouteasy(TopRouteIndividual roteirizacao);

        bool AdicionarVeiculos (List<TopRouteVeiculo> veiculos);

        bool putNaoRoteirizar(TopRouteItens putNaoRoteirizar);
        bool putLimparVeiculo(TopRouteVeiculo putLimparVeiculo);

        bool documento_baixa_routeasy(List<TopRouteDocumentosRoteirizados> documentos);
        List<TopRouteRotasDistribuicao> get_RotasDistibuicao(int cod_filiais);
        //TopRouteJobs getJobManifestosDocumentos(int codRotue,int codFilial);

        TopRoutePickingList GetPickingList(int cod_roteirizacao, int cod_filais, string veiculo);

        TopRouteLogin get_UsuariosLogin(string login, string password);
        List<TopRouteFiliaisUsuario> get_FiliaisUsuario(int codUsuario);
        List<TopRouteDocumentosRoteirizados> get_DocumentoRoteirizados(string dt_inicio, string dt_final);
        List<TopRouteVeiculo> getTopRouteVeiculos(string veiculo);
        



        List<TopRoute> All_Roteirizacao_Filial(int cod_filiais);
        List<TopRouteDashboard_Manager> dashboard_manager_ungroup(string dt_ini, string dt_fim , int cod_filial , int principal);
        List<TopRouteDashboard_Manager> dashboard_manager_agroup(string dt_ini, string dt_fim);

        //bool salvaCliente(cliente cliente);
        //bool salvateste([FromBody]object json);



        //bool atualizarCliente(cliente cliente);

        bool putSequencia(List<TopRouteItens> servicos);


        //bool postRoteasy(routeasyRetorno jsonRotorno);




        #region "VEICULOS"

        List<TopRouteVeiculo> get_TopRouteVeiculos(int id);

        TopRouteVeiculo get_TopRouteVeiculo(int id, int veiculo);

        List<TopRouteDetalheItensVeiculo> getTopRoute_DetalheItensVeiculo(int id, int veiculo);
        

        TopRouteUsuario getTopRouteUsuarioAutenticado(string login);
        



        #endregion
    }

    
}


namespace Routeasy.Models
{

    public interface IRoteirizacaoRepositorio_Routeasy
    {

        bool deliveriesReturn([FromBody]object json);

        bool deliveriesReturnProcess([FromBody]object json);

    }
}



