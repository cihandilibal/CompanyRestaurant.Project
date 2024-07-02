namespace Project.COREMVC.Models.RecipeDetails.RequestModels
{
    public class RecipeDetailRequestModel
    {
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public string Instruction { get; set; }
        public decimal IngredientQuantity { get; set; }
        public string Unit { get; set; }

    }
}
