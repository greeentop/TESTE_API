using System;

namespace LibraryEntityData
{
    public class TopRouteUsuario
    {

        public int COD_USUARIOS { get; set; }
        public int COD_FUNCIONARIOS { get; set; }

        public string LOGIN { get; set; }
        public string NOME { get; set; }
        public string CARGO { get; set; }

        public int COD_FILIAIS { get; set; }

        public Boolean FL_ATIVO { get; set; }
        public Boolean FL_BLOQUEADO { get; set; }
        public string EMAIL { get; set; }
        public String MGS { get; set; }
    }
}
