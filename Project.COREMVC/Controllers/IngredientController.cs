using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Ingredients.PageVMs;
using Project.COREMVC.Models.Ingredients.RequestModels;
using Project.COREMVC.Models.Ingredients.ResponseModels;
using Project.ENTITIES.Models;
using System.CodeDom;

namespace Project.COREMVC.Controllers
{
    public class IngredientController : Controller
    {
        readonly IIngredientManager _ingredientManager;

        public IngredientController(IIngredientManager ingredientManager)
        {
            _ingredientManager = ingredientManager;
        }
        
        public IActionResult Index()
        {
            List<IngredientResponseModel> ingredients = _ingredientManager.Select(x => new IngredientResponseModel
            {
                Name = x.Name,
                ID = x.ID,
                Amount = x.Amount,
                Unit = x.Unit,
                UnitPrice = x.UnitPrice
            }).ToList();
            decimal totalCost = _ingredientManager.Cost();

            IngredientsPageVM ipVm = new IngredientsPageVM()
            {
                Ingredients = ingredients,
                TotalCost = totalCost
            };
            return View(ipVm);
        }

        public IActionResult AddIngredient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredient(AddIngredientRequestModel item)
        {
            Ingredient i = new()
            {
                Name= item.Name,
                Amount= item.Amount,
                Unit= item.Unit,
                UnitPrice= item.UnitPrice
            };
            await _ingredientManager.AddAsync(i);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            _ingredientManager.Delete(await _ingredientManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DestroyCategory(int id)
        {
            _ingredientManager.Destroy(await _ingredientManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateIngredient(int id)
        {
            return View(await _ingredientManager.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIngredient(Ingredient ingredient)
        {
            await _ingredientManager.UpdateAsync(ingredient);
            return RedirectToAction("Index");
        }
    }
}
