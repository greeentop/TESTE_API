namespace LibraryEntityData
{
    public class TopRouteDocumentosRoteirizados
    {

        public int ID { get; set; }
        public int COD_FILIAIS { get; set; }
        public int COD_ROTEIRIZACAO { get; set; }
        public int COD_DOCUMENTOS { get; set; }
        public int PRIORIDADE { get; set; }
        public int COD_VEICULOS { get; set; }
        public int ID_DOCUMENTOS { get; set; }
        public int? COD_VIAGENS_ROTEIRIZACAO { get; set; }
        public int ORDEM_ENTREGA { get; set; }
        public string TIPO_ROUTER { get; set; }
        public string BAIXA { get; set; }
        public string TIPO_DOCUMENTOS { get; set; }
    }
}
