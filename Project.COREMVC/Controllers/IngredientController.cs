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
                ActualAmount = x.ActualAmount,
                ExpectedAmount = x.ExpectedAmount,
                Unit = x.Unit,
                UnitPrice = x.UnitPrice,
                Status = x.Status
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
        public async Task<IActionResult> AddIngredient(AddIngredientPageVM item)
        {
            Ingredient i = new()
            {
                Name= item.AddIngredientRequestModel.Name,
                ActualAmount= item.AddIngredientRequestModel.ActualAmount,
                Unit= item.AddIngredientRequestModel.Unit,
                UnitPrice= item.AddIngredientRequestModel.UnitPrice
            };
            await _ingredientManager.AddAsync(i);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Malzeme bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                _ingredientManager.Delete(await _ingredientManager.FindAsync(id));
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DestroyIngredient(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Malzeme bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                _ingredientManager.Destroy(await _ingredientManager.FindAsync(id));
                return RedirectToAction("Index");
            }
        }


        public async Task<IActionResult> UpdateIngredient(int id)
        {
           Ingredient ingredient = await _ingredientManager.FindAsync(id);
           UpdateIngredientVM updateIngredientVM = new UpdateIngredientVM();
            updateIngredientVM.ID = ingredient.ID;
            updateIngredientVM.Name = ingredient.Name;
            updateIngredientVM.ActualAmount = ingredient.ActualAmount;
            updateIngredientVM.ExpectedAmount = ingredient.ExpectedAmount;
            updateIngredientVM.Unit = ingredient.Unit;
            updateIngredientVM.UnitPrice = ingredient.UnitPrice;
            UpdateIngredientPageVM uipVm = new UpdateIngredientPageVM();
            uipVm.UpdateIngredientVM = updateIngredientVM;
            return View(uipVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIngredient(UpdateIngredientPageVM model)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.ID = model.UpdateIngredientVM.ID;
            ingredient.Name = model.UpdateIngredientVM.Name;
            ingredient.ActualAmount = model.UpdateIngredientVM.ActualAmount;
            ingredient.ExpectedAmount = model.UpdateIngredientVM.ExpectedAmount;
            ingredient.Unit = model.UpdateIngredientVM.Unit;
            ingredient.UnitPrice = model.UpdateIngredientVM.UnitPrice;
            await _ingredientManager.UpdateAsync(ingredient);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> CheckStock(int id)
        {
            TempData["Message"] = await _ingredientManager.ControlIngredient(id);
            return RedirectToAction("Index");
        }
    }
}
