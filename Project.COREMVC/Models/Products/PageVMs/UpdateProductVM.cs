namespace Project.COREMVC.Models.Products.PageVMs
{
    public class UpdateProductVM
    {
        public int ID { get; set; }
        public int? CategoryID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; }
    }
}
