using Project.ENTITIES.Enums;

namespace Project.COREMVC.Models.RecipeDetails.ResponseModels
{
    public class RecipeDetailResponseModel
    {
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public string Instruction { get; set; }
        public decimal IngredientQuantity { get; set; }
        public string Unit { get; set; }
        public DataStatus Status { get; set; }
    }
}
