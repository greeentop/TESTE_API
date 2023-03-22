using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntityData
{
    public class cliente
    {


        public string results { get; set; }

        public int Id { get; set; }
        public string Razao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string json { get; set; }
    }

    #region comentado
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }








    public class results
    {
        public List<routes> routes;

    };
    public class routes
    {

        public List<directions> directions;
        //public List<toll_info> toll_info;


        public string _id { get; set; }   //: "5ba0efc6c1897241e943cb2b",
        public string name { get; set; }   //: "Rota 1",
        public string vehicle { get; set; } //: "5b9a71b1c1897241e943c5cb",
        public string distance { get; set; }   //: 988.5247999999999,
        public string weight { get; set; }   //: 205,
        public string volume { get; set; }   //: 0,
        public string capacity_weight { get; set; }   //: 7800,
        public string capacity_volume { get; set; }   //: 46,
        public string occupancy_weight { get; set; }   //: 0.026282,
        public string occupancy_volume { get; set; }   //: 41.290992,
        public string total_cost_toll { get; set; }   //: 324.20000000000005,
        public string total_deliveries { get; set; }   //: 10,
        public string id { get; set; }   //: "5ba0efc6c1897241e943cb2b"

    };
    public class directions
    {
        public List<start> start;
        public List<end> end;

        //passo a passo da rota a ser seguidas ruas
        //public List<steps> steps;

        public string _id { get; set; }   //: "5ba0efc6c1897241e943cb35",
        public string distance { get; set; }   //: 430606.2,
        public string duration { get; set; }   //: 17310.6,
        public string polyline { get; set; }   //: "ninoCll_|GoJgCId@Kf@DRhCdDrApB|DpFlAdBFHKHmK~IiA`A{GxFINAJBLPPnApBbB`CiBdAULc@VkAn@_Bx@sA|@QNkA~@YXa@b@W\\KXaAdC[fAUr@g@nA_@z@aAt
        public string source { get; set; }   //: "osrm.local"


    };

    public class start
    {
        //inicio (saida)
        public string depot { get; set; } //"depot": "5b89991a5d0e665a4f155f6c"
    };

    public class end
    {
        //final(chegadada)
        public string delivery { get; set; }
    };
    #endregion


}