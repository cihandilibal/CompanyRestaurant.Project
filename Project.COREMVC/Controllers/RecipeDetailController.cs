using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.RecipeDetails.PageVMs;
using Project.COREMVC.Models.RecipeDetails.RequestModels;
using Project.COREMVC.Models.RecipeDetails.ResponseModels;
using Project.COREMVC.Models.Recipes.ResponseModels;
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
            List<RecipeDetailResponseModel> recipeDetails;
            recipeDetails = _recipeDetailManager.Select(x => new RecipeDetailResponseModel
            {
                RecipeID = x.ID,
                IngredientID = x.IngredientID,
                Instruction = x.Instruction,
                IngredientQuantity = x.IngredientQuantity,
                Unit = x.Unit,
                Status = x.Status

            }).ToList();

            RecipeDetailsPageVM rdpVm = new RecipeDetailsPageVM()
            {
                RecipeDetails = recipeDetails
            };
            return View(rdpVm);
        }

        public IActionResult AddRecipeDetail()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddRecipeDetail(AddRecipeDetailPageVM model)
        {
            RecipeDetail rd = new RecipeDetail()
            {    RecipeID = model.RecipeDetailRequestModel.RecipeID,
                IngredientID = model.RecipeDetailRequestModel.IngredientID,
                Instruction =model.RecipeDetailRequestModel.Instruction,
                IngredientQuantity = model.RecipeDetailRequestModel.IngredientQuantity,
                Unit = model.RecipeDetailRequestModel.Unit
            };
            await _recipeDetailManager.AddAsync(rd);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteRecipeDetail(int recipeId, int ingredientId)
        {
            RecipeDetail originaldata = await _recipeDetailManager.FirstOrDefaultAsync(x => x.RecipeID == recipeId && x.IngredientID == ingredientId);
            _recipeDetailManager.Destroy(originaldata);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroyRecipeDetail(int recipeId, int ingredientId)
        {
            RecipeDetail originaldata = await _recipeDetailManager.FirstOrDefaultAsync(x => x.RecipeID == recipeId && x.IngredientID == ingredientId);
            _recipeDetailManager.Destroy(originaldata);
            return RedirectToAction("Index");
        }
    }
}
