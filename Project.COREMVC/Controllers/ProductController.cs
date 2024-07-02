using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.COREMVC.Models.Products.PageVM;

namespace Project.COREMVC.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductManager _productManager;
        readonly ICategoryManager _categoryManager;

        public ProductController(IProductManager productManager, ICategoryManager categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            return View(_productManager.GetAll());
        }

        public IActionResult CreateProduct()
        {
            CreateProductPageVM cpVm = new()
            {
                Categories = _categoryManager.GetActives()
            };
            return View(cpVm);

        } 
    }
        
}
