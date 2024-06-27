using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Areas.Manager.Models.Categories.RequestModels;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class CategoryController : Controller
    {
        readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        public IActionResult Index()
        {
            return View (_categoryManager.GetAll());
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
            TempData["Message"] = _categoryManager.Destroy(await _categoryManager.FindAsync(id));
            return RedirectToAction("Index");
        }

    }
}
