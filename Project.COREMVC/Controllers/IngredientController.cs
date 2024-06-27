using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Ingredients.RequestModels;
using Project.ENTITIES.Models;

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
            return View(_ingredientManager.GetActives());
        }

        public async Task<IActionResult> AddIngredient()
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
                UnitPrice= item.UnitPrice,
            };
            await _ingredientManager.AddAsync(i);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            _.Delete(await _ingredientManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DestroyCategory(int id)
        {
            TempData["Message"] = _ingredientManager.Destroy(await _ingredientManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateIngredient(int id)
        {
            return View(await _ingredientManager.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIngredient()
        {
            return View();

        }
        public IActionResult CalculateCost()
        {
            return View (_ingredientManager.Cost());
        }

      


    }
}
