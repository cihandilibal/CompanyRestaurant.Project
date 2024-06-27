namespace Project.COREMVC.Models.Ingredients.RequestModels
{
    public class AddIngredientRequestModel
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
    }   
}
