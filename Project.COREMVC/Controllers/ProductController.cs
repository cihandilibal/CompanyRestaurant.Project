using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Products.PageVM;
using Project.COREMVC.Models.Products.RequestModels;
using Project.COREMVC.Models.Products.ResponseModels;
using Project.ENTITIES.Models;

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

        public IActionResult Index(int? categoryID)
        {
            List<ProductResponseModel> products;

            if (categoryID.HasValue)
            {
                products = _productManager.Where(x => x.CategoryID == categoryID).Select(x => new ProductResponseModel
                {
                    ID = x.ID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    Unit = x.Unit,
                    CategoryName = x.Category.CategoryName
                }).ToList();
            }
            else
            {
                products = _productManager.Select(x => new ProductResponseModel
                {
                    ID = x.ID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    Unit = x.Unit,
                    CategoryName = x.Category.CategoryName
                }).ToList();
            }

            return View(products);
        }

        public IActionResult CreateProduct()
        {
            CategoriesPageVM cpVm = new()
            {
                Categories = _categoryManager.GetActives()
            };
            return View(cpVm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequestModel model)
        {
            Product p = new Product()
            {
                ProductName = model.ProductName,
                CategoryID = model.CategoryID,
                UnitPrice = model.UnitPrice,
                Unit = model.Unit
            };
            await _productManager.AddAsync(p);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            _productManager.Delete(await _productManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DestroyProduct(int id)
        {
            _productManager.Destroy(await _productManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateProduct(int id)
        {
            return View(await _productManager.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product item)
        {
            await _productManager.UpdateAsync(item);
            return RedirectToAction("Index");
        }
    }    
}
