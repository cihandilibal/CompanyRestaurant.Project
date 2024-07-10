namespace Project.COREMVC.Models.Payments.PageVMs
{
    public class UpdatePaymentVM
    {
        public int ID { get; set; }
        public int OrderNo { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
    }
}
