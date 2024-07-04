﻿namespace Project.COREMVC.Models.OrderDetails.ResponseModels
{
    public class OrderDetailsResponseModel
    {
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}