using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntityData.Routeasy.Model.Retorno
{
    public class directions
    {



        public List<start> start { get; set; }
        public List<end> end { get; set; }
        public List<steps> steps { get; set; }
        public int _id { get; set; }//"_id": "5baa8eb84949734db
        public int distance { get; set; }//"distance": 431640.5,
        public int duration { get; set; }//"duration": 18326,
        public int polyline { get; set; }//"polyline": "ninoCll_|GoJ
        public int source { get; set; }//"source": "osrm.local"

    }
}
