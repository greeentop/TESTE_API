using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntityData.Routeasy.Model.Retorno
{
    public class delivery
    {



        public constraints constraints { get; set; }

        public address address { get; set; }

        public string geocode_status { get; set; } //"geocode_status": "found_with_warning",
        public string service_time { get; set; } //"service_time": 15,
        public string service_type { get; set; } //"service_type": "delivery",
        public string _id { get; set; } //"_id": "5bc505e0e0584422f1c853b1",

        public List<addresses_supplied> addresses_supplied { get; set; }

        public string code { get; set; }//"code": "283232",
        public string name { get; set; }//"name": "AGROTOTAL COMERCIAL LTDA",
        public string invoice_number { get; set; }//"invoice_number": "0",
        public string order_number { get; set; }//"order_number": "0",
        public string additional_info_1 { get; set; }//"additional_info_1": "",
        public string additional_info_2 { get; set; }//"additional_info_2": "",
        public string weight { get; set; }//"weight": 28.62,
        public string volume { get; set; }//"volume": 0,
        public string email { get; set; }//"email": "",
        public string phone { get; set; }//"phone": ""



        




    }
}


