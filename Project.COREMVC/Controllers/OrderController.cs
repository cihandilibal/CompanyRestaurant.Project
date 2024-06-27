using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.ENTITIES.Models;
using Project.COREMVC.Models.Orders.RequestModels;


namespace Project.COREMVC.Controllers
{
    public class OrderController : Controller
    { 
        readonly IProductManager _productManager;
        readonly ICategoryManager _categoryManager;
        readonly IOrderManager _orderManager;
        readonly IOrderDetailManager _orderDetailManager;
        readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IProductManager productManager, ICategoryManager categoryManager, IOrderDetailManager orderDetailManager, IOrderManager orderManager, IHttpClientFactory httpClientFactory)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _orderDetailManager = orderDetailManager;
            _orderManager = orderManager;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View(_orderManager.GetActives());
        }
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequestModel model)
        {
            return View();
        }



    }
}
