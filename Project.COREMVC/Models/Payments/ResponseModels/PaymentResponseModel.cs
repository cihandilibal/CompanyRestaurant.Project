﻿using Project.ENTITIES.Models;

namespace Project.COREMVC.Models.Payments.ResponseModels
{
    public class PaymentResponseModel
    {   
        public int ID { get; set; }
       public decimal Price { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public int OrderID { get; set; }

    }
}
