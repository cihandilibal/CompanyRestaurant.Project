namespace Project.COREMVC.Models.Payments.ResponseModels
{
    public class DailyPaymentResponseModel
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
       
    }
} 
