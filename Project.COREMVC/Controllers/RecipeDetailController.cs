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
                IngredientName = x.Ingredient.Name,
                Instruction = x.Instruction,
                IngredientQuantity = x.IngredientQuantity,
                Unit = x.Unit
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
            RecipeDetail recipeDetail = await _recipeDetailManager.FindAsync(recipeId);
            UpdateDetailVM updateDetailVM = new UpdateDetailVM();
            updateDetailVM.RecipeID = recipeDetail.RecipeID;
            updateDetailVM.IngredientID = recipeDetail.IngredientID;
            updateDetailVM.IngredientQuantity = recipeDetail.IngredientQuantity;
            updateDetailVM.Unit = recipeDetail.Unit;
            updateDetailVM.Instruction = recipeDetail.Instruction;
            UpdateDetailPageVM udpVm = new UpdateDetailPageVM();
            udpVm.UpdateDetailVM = updateDetailVM;
            return View(udpVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecipeDetail(UpdateDetailPageVM model)
        {
            RecipeDetail recipeDetail = new RecipeDetail();
            recipeDetail.RecipeID = model.UpdateDetailVM.RecipeID;
            recipeDetail.IngredientID = model.UpdateDetailVM.IngredientID;
            recipeDetail.IngredientQuantity = model.UpdateDetailVM.IngredientQuantity;
            recipeDetail.Unit = model.UpdateDetailVM.Unit;
            recipeDetail.Instruction = model.UpdateDetailVM.Instruction;
            await _recipeDetailManager.UpdateAsync(recipeDetail);
            return RedirectToAction("Index");
        }


    }
}
