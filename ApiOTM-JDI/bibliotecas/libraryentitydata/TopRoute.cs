using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}
