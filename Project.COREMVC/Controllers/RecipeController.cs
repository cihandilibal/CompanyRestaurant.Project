using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Recipes.RequestModels;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Controllers
{
    public class RecipeController : Controller
    {
        readonly IRecipeManager _recipeManager;

        public RecipeController(IRecipeManager recipeManager)
        {
            _recipeManager = recipeManager;
        }

        public IActionResult Index()
        {
            return View(_recipeManager.GetActives());
        }

        public async Task<IActionResult> CreateRecipe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(CreateRecipeRequestModel item)
        {
            
           Recipe r = new Recipe()
           {
              ID = item.ID,
              Name = item.Name,
              Instruction = item.Instruction
             
           };
           await _recipeManager.AddAsync(r);
           return View("Index");
        }

    }
}
