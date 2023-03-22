using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntityData.Routeasy
{





    




    //father toll
    public class toll_info
    {
        public List<tolls_square> tolls_square;
        public string _id { get; set; }   //: "5ba0eff3c1897241e943cd2c",
        public string request { get; set; }   //: "5ba0eff3c1897241e943cd2b",
        public string has_tolls { get; set; }   //: true,
        public string total_cost { get; set; }   //: 324.20000000000005,
        public string id { get; set; }   //: "5ba0eff3c1897241e943cd2c"

    };

    //son father toll
    public class tolls_square
    {
        public string _id { get; set; } //: "5ba0eff3c1897241e943cd3d",
        public string id_api { get; set; } //: "1616",
        public string id_sem_parar { get; set; } //: "60",
        public string tolls_company { get; set; } //: "AUTOBAN",
        public string tolls_name { get; set; } //: "Caieiras",
        public string state { get; set; } //: "SP",
        public string road { get; set; } //: "SP-348",
        public string road_km { get; set; } //: "36.2",
        public string price { get; set; } //: 18.4,
        public string lat { get; set; } //: -23.347122,
        public string lng { get; set; } //: -46.813321

    }














}
