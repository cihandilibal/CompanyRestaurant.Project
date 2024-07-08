namespace Project.COREMVC.Models.RecipeDetails.ResponseModels
{
    public class RecipeDetailResponseModel
    {
        public int RecipeID { get; set; }
        public string IngredientName { get; set; }
        public string Instruction { get; set; }
        public decimal IngredientQuantity { get; set; }
        public string Unit { get; set; }
    }
}
