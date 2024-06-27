using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.RecipeDetails.RequestModels;
namespace Project.COREMVC.Controllers
{
    public class RecipeDetailController : Controller
    {
        readonly IRecipeDetailManager _recipeDetailManager;

        public RecipeDetailController(IRecipeDetailManager recipeDetailManager)
        {
            _recipeDetailManager = recipeDetailManager;
        }

        public IActionResult Index()
        {
            return View(_recipeDetailManager.GetActives());
        }

        public async Task<IActionResult> CreateRecipeDetail()
        {
            return View();
        }

        [HttpPost]

        public async Task <IActionResult> CreateRecipeDetail(RecipeDetailRequestModel model )
        {
            return View();
        }
    }
}
