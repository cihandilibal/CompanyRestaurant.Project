using Microsoft.AspNetCore.Razor.TagHelpers;
using Project.ENTITIES.Models;

namespace Project.COREMVC.CustomTagHelper
{
    [HtmlTargetElement("a", Attributes = "recipe-id,ingredient-id")]
    public class MyTagHelper_1 : TagHelper
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("asp-route-recipeId", RecipeId);
            output.Attributes.SetAttribute("asp-route-ingredientId", IngredientId);

        }
   
    }
}
