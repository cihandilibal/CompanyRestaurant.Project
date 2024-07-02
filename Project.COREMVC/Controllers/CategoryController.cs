using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.COREMVC.Models.Categories.PageVMs;
using Project.COREMVC.Models.Categories.RequestModels;
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
            return View(_categoryManager.GetAll());
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestModel item)
        {
            Category ca = new()
            {
                CategoryName = item.CategoryName,
                Description = item.Description
            };
            await _categoryManager.AddAsync(ca);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _categoryManager.Delete(await _categoryManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DestroyCategory(int id)
        {
            _categoryManager.Destroy(await _categoryManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateCategory(int id)
        {
            return View(await _categoryManager.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            await _categoryManager.UpdateAsync(category);
            return RedirectToAction("Index");
        }

    }
}
