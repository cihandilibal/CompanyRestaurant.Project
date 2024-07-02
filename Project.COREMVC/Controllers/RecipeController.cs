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
              Name = item.Name,
           };
           await _recipeManager.AddAsync(r);
           return View("Index");
        }
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            _recipeManager.Delete(await _recipeManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DestroyRecipe(int id)
        {
            _recipeManager.Destroy(await _recipeManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateRecipe(int id)
        {
            return View(await _recipeManager.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Recipe recipe)
        {
            await _recipeManager.UpdateAsync(recipe);
            return RedirectToAction("Index");
        }
    }
}
