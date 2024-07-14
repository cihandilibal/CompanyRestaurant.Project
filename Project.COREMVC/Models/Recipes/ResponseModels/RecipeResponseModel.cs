using Project.ENTITIES.Enums;

namespace Project.COREMVC.Models.Recipes.ResponseModels
{
    public class RecipeResponseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DataStatus Status { get; set; }
    }
}
