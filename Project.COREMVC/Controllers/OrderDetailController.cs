using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.ENTITIES.Models;
using Project.COREMVC.Models.OrderDetails.PageVMs;
using Project.COREMVC.Models.OrderDetails.ResponseModels;
using Microsoft.CodeAnalysis;
using Project.BLL.Managers.Concretes;
using System;



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
                ProductID = x.ProductID,
                Quantity = x.Quantity,
                Unit = x.Unit,
                UnitPrice = x.UnitPrice,
                TotalPrice = x.TotalPrice,
                Status = x.Status
            }).ToList();

            OrderDetailsPageVM odpVm = new OrderDetailsPageVM()
            {
                OrderDetails = orderDetails
            };
            return View(odpVm);
        }

        public IActionResult AddDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDetail(AddOrderDetailPageVM model)
        {

            OrderDetail od = new()
            {
                OrderID = model.OrderDetailRequestModel.OrderID,
                ProductID = model.OrderDetailRequestModel.ProductID,
                Quantity = model.OrderDetailRequestModel.Quantity,
                Unit = model.OrderDetailRequestModel.Unit,
                UnitPrice = model.OrderDetailRequestModel.UnitPrice,
                TotalPrice = model.OrderDetailRequestModel.TotalPrice
            };

            await _orderDetailManager.AddAsync(od);
            return RedirectToAction("GetOrderDetails");
        }
        public async Task<IActionResult> DeleteOrderDetail(int orderId, int productId)
        {
            OrderDetail originaldata = await _orderDetailManager.FirstOrDefaultAsync(x => x.OrderID == orderId && x.ProductID == productId);
             _orderDetailManager.Delete(originaldata);
            return RedirectToAction("GetOrderDetails");
        }

        public async Task<IActionResult> DestroyOrderDetail(int orderId, int productId)
        {
            OrderDetail originaldata = await _orderDetailManager.FirstOrDefaultAsync(x => x.OrderID == orderId && x.ProductID == productId);
            _orderDetailManager.Destroy(originaldata);
            return RedirectToAction("GetOrderDetails");
        }
    }
    
}
