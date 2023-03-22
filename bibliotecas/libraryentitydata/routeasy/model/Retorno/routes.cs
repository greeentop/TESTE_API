using System.Collections.Generic;

namespace LibraryEntityData.Routeasy.Model.Retorno
{
    public class routes
    {

        public List<delivery_order> delivery_order { get; set; }
        public List<directions> directions { get; set; }
        public List<toll_info> toll_info { get; set; }
        public string _id { get; set; } //"_id": "5ba315e94949734dbd3c5347",
        public string name { get; set; } //"name": "Rota 1",
        public string vehicle { get; set; } //"vehicle": "5b9a71b1c1897241e943c5cb",
        public string distance { get; set; } //"distance": 1003.7544,
        public string weight { get; set; } //"weight": 205,
        public string volume { get; set; } //"volume": 0,
        public string capacity_weight { get; set; } //"capacity_weight": 7800,
        public string capacity_volume { get; set; } //"capacity_volume": 46,
        public string occupancy_weight { get; set; } //"occupancy_weight": 0.026282,
        public string occupancy_volume { get; set; } //"occupancy_volume": 41.900176,
        public string total_cost_toll { get; set; } //"total_cost_toll": 324.20000000000005,
        public string total_deliveries { get; set; } //"total_deliveries": 10,
        public string id { get; set; } //"id": "5ba315e94949734dbd3c5347"
    }
}
