﻿namespace Project.COREMVC.Models.OrderDetails.RequestModels
{
    public class OrderDetailRequestModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
