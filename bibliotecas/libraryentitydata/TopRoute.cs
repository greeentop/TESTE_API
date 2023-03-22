using System;

namespace LibraryEntityData
{
    public class TopRoute
    {
        public int ID { get; set; }
        public int CODIGO_ROTEIRIZACAO { get; set; }
        public int CODIGO_FILIAIS { get; set; }
        public String ENVIO_NS { get; set; }
        public String RETORNO_OTM { get; set; }
        public int QTD_ROTAS { get; set; }
        public int  QTD_COLETAS { get; set; }
        public int QTD_ENTREGAS { get; set; }
        public int QTD_VEICULOS { get; set; }
        public int  QTD_VIAGENS { get; set; }
        public  int KM_TOTAL { get; set; }
        public int QTD_ENTREGAS_ENVIO { get; set; }
        public int QTD_COLETAS_ENVIO { get; set; }


        public int QTD_VEICULOS_ENVIO { get; set; }


        public int DISTANCIA_VEICULOS_PROPRIOS { get; set; }
        public int DISTANCIA_VEICULOS_AGREGRADOS { get; set; }
        public int PESO_VEICULOS_PROPRIOS { get; set; }
        public int PESO_VEICULOS_AGREGRADOS { get; set; }
        public int OCUPACAO_VEICULOS_MEDIA_PROPRIOS { get; set; }
        public int OCUPACAO_VEICULOS_MEDIA_AGREGRADOS { get; set; }
        public int QTD_VEICULOS_PROPRIOS { get; set; }
        public int QTD_VEICULOS_AGREGADOS { get; set; }
        public string DT_ROTEIRIZACAO { get; set; }

        public  int QTD_SERVICOS  { get; set; }
        public int QTD_SERVICOS_PROPRIOS { get; set; }
        public int QTD_SERVICOS_AGREGADOS { get; set; }
        public int PERCENT_SERVICOS_PROPRIOS { get; set; }

        public int PERCENT_SERVICOS_AGREGADOS { get; set; }

        public int QTD_SERVICOS_ALL { get; set; }


        public int QTD_SERVICOS_MANUAL { get; set; }
        public int QTD_SERVICOS_TOPROUTE { get; set; }
        public int QTD_SERVICOS_ROUTEASY { get; set; }

        public string messageError { get; set; }



    }
}
