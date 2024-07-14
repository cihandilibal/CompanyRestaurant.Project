using Project.ENTITIES.Enums;

namespace Project.COREMVC.Models.OrderDetails.ResponseModels
{
    public class OrderDetailsResponseModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DataStatus Status { get; set; }
    }
}
