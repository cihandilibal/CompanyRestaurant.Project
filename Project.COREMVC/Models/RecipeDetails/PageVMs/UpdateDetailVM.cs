namespace Project.COREMVC.Models.RecipeDetails.PageVMs
{
    public class UpdateDetailVM
    {
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public string Instruction { get; set; }
        public decimal IngredientQuantity { get; set; }
        public string Unit { get; set; }
    }
}
