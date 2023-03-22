using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntityData.Routeasy.Model.Retorno
{
    public class address
    {
        public geocode geocode { get; set; }

        public string route { get; set; }//"route": "R SAO CAETANO",
        public string street_number { get; set; }//"street_number": "AGROTOTAL COMERCIAL LTDA",
        public string neighborhood { get; set; }//"neighborhood": "LUZ",
        public string city { get; set; }//"city": "SAO PAULO",
        public string state { get; set; }//"state": "SP",
        public string postal_code { get; set; }//"postal_code": "01104000",
        public string country { get; set; }//"country": "BRASIL"

    }
}
