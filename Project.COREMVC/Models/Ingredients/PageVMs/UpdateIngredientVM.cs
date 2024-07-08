namespace Project.COREMVC.Models.Ingredients.PageVMs
{
    public class UpdateIngredientVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal PredictedAmount { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
