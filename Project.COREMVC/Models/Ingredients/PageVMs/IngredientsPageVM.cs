using Project.COREMVC.Models.Ingredients.ResponseModels;

namespace Project.COREMVC.Models.Ingredients.PageVMs
{
    public class IngredientsPageVM
    {
        public List<IngredientResponseModel> Ingredients { get; set; }
        public decimal TotalCost { get; set; }
    }
}
