﻿using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.ENTITIES.Models;
using Project.COREMVC.Models.Recipes.ResponseModels;
using Project.COREMVC.Models.Recipes.PageVMs;
using Project.BLL.Managers.Concretes;

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
            List<RecipeResponseModel> recipes;
            recipes = _recipeManager.Select(x => new RecipeResponseModel
            {
                ID = x.ID,
                Name = x.Name,
                Status = x.Status
            }).ToList();
            GetRecipesPageVM grpVm = new GetRecipesPageVM()
            {
                Recipes = recipes
            };
            return View(grpVm);
        }

        public IActionResult CreateRecipe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(CreateRecipePageVM model)
        {

            Recipe r = new Recipe()
            {
                Name = model.CreateRecipeRequestModel.Name
            };
           await _recipeManager.AddAsync(r);
           return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRecipe(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Urun recetesi bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                _recipeManager.Delete(await _recipeManager.FindAsync(id));
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DestroyRecipe(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Urun recetesi bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                _recipeManager.Destroy(await _recipeManager.FindAsync(id));
                return RedirectToAction("Index");
            }
        }


        public async Task<IActionResult> UpdateRecipe(int id)
        {
            Recipe recipe = await _recipeManager.FindAsync(id);
            UpdateRecipeVM updateRecipeVM = new UpdateRecipeVM();
            updateRecipeVM.ID = recipe.ID;
            updateRecipeVM.Name = recipe.Name;
            UpdateRecipePageVM urpVm = new UpdateRecipePageVM();
            urpVm.UpdateRecipeVM = updateRecipeVM;
            return View(urpVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecipe(UpdateRecipePageVM model) 
        {
            Recipe recipe = new Recipe();
            recipe.ID = model.UpdateRecipeVM.ID;
            recipe.Name = model.UpdateRecipeVM.Name;
            await _recipeManager.UpdateAsync(recipe);
            return RedirectToAction("Index");
        }
    }
}
