namespace Project.COREMVC.Models.Ingredients.ResponseModels
{
    public class IngredientResponseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal PredictedAmount { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
