namespace Project.COREMVC.Models.Payments.RequestModels
{
    public class PaymentRequestModel
    {
        public int OrderID { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
    }
}
