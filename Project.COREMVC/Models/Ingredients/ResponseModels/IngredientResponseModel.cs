using Project.ENTITIES.Enums;

namespace Project.COREMVC.Models.Ingredients.ResponseModels
{
    public class IngredientResponseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal ActualAmount { get; set; }
        public decimal ExpectedAmount { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public DataStatus Status { get; set; }
    }
}
