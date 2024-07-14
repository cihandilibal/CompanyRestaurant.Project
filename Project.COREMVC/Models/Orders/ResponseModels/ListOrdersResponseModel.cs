using Project.ENTITIES.Enums;

namespace Project.COREMVC.Models.Orders.ResponseModels
{
    public class ListOrdersResponseModel
    {
        public int ID { get; set; }
        public int TableNo { get; set; }
        public DateTime OrderTime { get; set; }
        public DataStatus Status { get; set; }
    }
}
