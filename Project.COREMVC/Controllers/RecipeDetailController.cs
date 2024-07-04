using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.RecipeDetails.RequestModels;
using Project.ENTITIES.Models;
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

        public IActionResult AddRecipeDetail()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddRecipeDetail(RecipeDetailRequestModel model)
        {
            RecipeDetail rd = new RecipeDetail()
            {
                RecipeID = model.RecipeID,
                IngredientID = model.IngredientID,
                Instruction =model.Instruction,
                IngredientQuantity = model.IngredientQuantity,
                Unit = model.Unit
            };
            await _recipeDetailManager.AddAsync(rd);
            return View("Index");
        }
        public async Task<IActionResult> DeleteRecipeDetail(int recipeId)
        {
            _recipeDetailManager.Delete(await _recipeDetailManager.FindAsync(recipeId));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroyRecipeDetail(int recipeId)
        {
            _recipeDetailManager.Destroy(await _recipeDetailManager.FindAsync(recipeId));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateRecipeDetail(int recipeId)
        {
            return View(await _recipeDetailManager.FindAsync(recipeId));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecipeDetail(RecipeDetail item)
        {
            await _recipeDetailManager.UpdateAsync(item);
            return RedirectToAction("Index");
        }


    }
}
