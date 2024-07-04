namespace Project.COREMVC.Models.Products.RequestModels
{
    public class CreateProductRequestModel
    {
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; }
    }
}
