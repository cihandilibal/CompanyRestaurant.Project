using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Categories.PageVMs;
using Project.COREMVC.Models.Categories.RequestModels;
using Project.COREMVC.Models.Categories.ResponseModels;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        public IActionResult Index()
        {
            List<GetCategoriesResponseModel> categories = _categoryManager.Select(x => new GetCategoriesResponseModel
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Status = x.Status
            }).ToList();
            GetCategoriesPageVM gcpVm = new GetCategoriesPageVM()
            {
                Categories = categories
            };
            return View(gcpVm);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryPageVM item)
        {
            Category ca = new()
            {
                CategoryName = item.CreateCategoryRequestModel.CategoryName,
                Description = item.CreateCategoryRequestModel.Description
            };
            await _categoryManager.AddAsync(ca);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Kategori bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                _categoryManager.Delete(await _categoryManager.FindAsync(id));
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DestroyCategory(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Kategori bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                _categoryManager.Destroy(await _categoryManager.FindAsync(id));
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            Category category = await _categoryManager.FindAsync(id);
            UpdateCategoryVM updateCategoryVM = new UpdateCategoryVM();
            updateCategoryVM.ID = category.ID;
            updateCategoryVM.CategoryName = category.CategoryName;
            updateCategoryVM.Description = category.Description;
            UpdateCategoryPageVM ucpVm = new UpdateCategoryPageVM();
            ucpVm.UpdateCategoryVM= updateCategoryVM;
            return View(ucpVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryPageVM model)
        {
            Category category = new Category();
            category.ID = model.UpdateCategoryVM.ID;
            category.CategoryName = model.UpdateCategoryVM.CategoryName;
            category.Description = model.UpdateCategoryVM.Description;
            await _categoryManager.UpdateAsync(category);
            return RedirectToAction("Index");
        }

    }
}
