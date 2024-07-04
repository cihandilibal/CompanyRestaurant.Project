using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.OrderDetails.PageVMs;
using Project.COREMVC.Models.OrderDetails.RequestModels;
using Project.COREMVC.Models.OrderDetails.ResponseModels;
using Project.ENTITIES.Models;


namespace Project.COREMVC.Controllers
{
    public class OrderDetailController : Controller
    {
        readonly IOrderDetailManager _orderDetailManager;

        public OrderDetailController(IOrderDetailManager orderDetailManager)
        {
            _orderDetailManager = orderDetailManager;
        }

        public IActionResult GetOrderDetails()
        {
            List<OrderDetailsResponseModel> orderDetails = _orderDetailManager.Select(x => new OrderDetailsResponseModel
            {
                OrderID = x.OrderID,
                ProductName =  x.Product.ProductName,
                Quantity = x.Quantity,
                Unit = x.Unit,
                UnitPrice = x.UnitPrice
            }).ToList();
            decimal totalPrice = _orderDetailManager.PriceOfOrder();

            OrderDetailsPageVM odpVm = new OrderDetailsPageVM()
            {
                OrderDetails = orderDetails,
                TotalPrice = totalPrice
            };
            return View(odpVm);
        }
           
        public IActionResult AddDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDetail(OrderDetailRequestModel model)
        {
            OrderDetail od = new()
            {
                OrderID = model.OrderID,
                ProductID = model.ProductID,
                Quantity = model.Quantity,
                Unit = model.Unit,
                UnitPrice = model.UnitPrice,
            };

            await _orderDetailManager.AddAsync(od);
            return RedirectToAction("GetOrderDetails");
        }
        public async Task<IActionResult> DeleteDetail(int orderId)
        {
            _orderDetailManager.Delete(await _orderDetailManager.FindAsync(orderId));
            return RedirectToAction("GetOrderDetails");
        }

        public async Task<IActionResult> DestroyDetail(int orderId)
        {
            _orderDetailManager.Destroy(await _orderDetailManager.FindAsync(orderId));
            return RedirectToAction("GetOrderDetails");
        }
        public async Task<IActionResult> UpdateDetail(int orderId)
        {
            return View(await _orderDetailManager.FindAsync(orderId));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetail(OrderDetail item)
        {
            await _orderDetailManager.UpdateAsync(item);
            return RedirectToAction("ListOrders");
        }
        
    }

}
