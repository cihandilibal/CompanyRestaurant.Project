using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Payments.PageVMs;
using Project.COREMVC.Models.Products.PageVMs;
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

        public IActionResult Index()
        {
            List<ProductResponseModel> products;

            products = _productManager.Select(x => new ProductResponseModel
            {
                 ID = x.ID,
                 ProductName = x.ProductName,
                 UnitPrice = x.UnitPrice,
                 Unit = x.Unit,
                 CategoryName = x.Category.CategoryName,
                 Status = x.Status
            }).ToList();
            GetProductsPageVM gppVM = new GetProductsPageVM()
            {
                Products = products
            };
            return View(gppVM);
        }

        public IActionResult CreateProduct()
        {
            List<CategoryResponseModel> categories;

            categories = _categoryManager.Select(x => new CategoryResponseModel
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
            }).ToList();
            CreateProductPageVM cppVm = new CreateProductPageVM()
            {
                Categories = categories
            };
            return View(cppVm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductPageVM model)
        {
            Product p = new Product()
            {
                ProductName = model.CreateProductRequestModel.ProductName,
                CategoryID = model.CreateProductRequestModel.CategoryID,
                UnitPrice = model.CreateProductRequestModel.UnitPrice,
                Unit = model.CreateProductRequestModel.Unit
            };
            await _productManager.AddAsync(p);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Urun bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                _productManager.Delete(await _productManager.FindAsync(id));
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DestroyProduct(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Urun bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                _productManager.Destroy(await _productManager.FindAsync(id));
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            Product product = await _productManager.FindAsync(id);
            UpdateProductVM updateProductVM = new UpdateProductVM();
            updateProductVM.ID = product.ID;
            updateProductVM.CategoryID = (int)product.CategoryID;
            updateProductVM.ProductName = product.ProductName;
            updateProductVM.Unit = product.Unit;
            updateProductVM.UnitPrice = product.UnitPrice;
            UpdateProductPageVM uppVm = new UpdateProductPageVM();
            uppVm.UpdateProductVM = updateProductVM;
            return View(uppVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductPageVM model)
        {
            Product product = new Product();
            product.ID = model.UpdateProductVM.ID;
            product.CategoryID = model.UpdateProductVM.CategoryID;
            product.ProductName = model.UpdateProductVM.ProductName;
            product.Unit = model.UpdateProductVM.Unit;
            product.UnitPrice = product.UnitPrice;
            await _productManager.UpdateAsync(product);
            return RedirectToAction("Index");
        }
    }    
}
