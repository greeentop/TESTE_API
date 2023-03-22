using System;

namespace LibraryEntityData
{
    public class OTMRoteirizacaoIntegracao
    {

        public int Id { get; set; }
        public int CODIGO_ROTEIRIZACAO { get; set; }
        public DateTime? DATA_RETORNO_OTM{ get; set; }
        public DateTime DATA_INCLUSAO { get; set; }
        public string XML_RETORNO_OTM { get; set; }
        public string XML_DOCUMENTOS_ENVIADOS_OTM { get; set; }          
        public string XML_VEIUCLOS_ENVIADO_OTM { get; set; }
        public string XML_RETORNO_ENVIO_DOCUMENTOS { get; set; }
        public string XML_RETERNO_ENVIO_VEICULOS { get; set; }
        public DateTime? DATA_ENVIO_XML_VEICULOS { get; set; }
        public DateTime? DT_ENVIO_XML_DOCUMENTOS { get; set; }



    }
}
