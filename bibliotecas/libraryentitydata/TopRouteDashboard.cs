using System;

namespace LibraryEntityData
{
    public class TopRouteDashboard
    {
        /// <summary>
        /// Retorno  do OTM lembran do que essa dash antes de enviar para o NS vai esta carregada com informacoes do NS
        /// </summary>
        public int ID { get; set; }
        public int CODIGO_ROTEIRIZACAO { get; set; }
        public int CODIGO_FILIAIS { get; set; }
        public String ENVIO_NS { get; set; }
        public String RETORNO_OTM { get; set; }
        public String QTD_ROTAS { get; set; }
        public String QTD_COLETAS { get; set; }
        public String QTD_ENTREGAS { get; set; }
        public String QTD_VEICULOS { get; set; }
        public String QTD_VIAGENS { get; set; }
        public Int32 KM_TOTAL { get; set; }
    }
}
