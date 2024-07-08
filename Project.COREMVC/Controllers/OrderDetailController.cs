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
                UnitPrice = x.UnitPrice,
                TotalPrice = x.TotalPrice
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
                TotalPrice =model.OrderDetailRequestModel.TotalPrice
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
           OrderDetail orderDetail =  await _orderDetailManager.FindAsync(orderId);
           UpdateOrderDetailVM updateOrderDetailVM = new UpdateOrderDetailVM();
            updateOrderDetailVM.OrderID = orderDetail.OrderID;
            updateOrderDetailVM.ProductID = orderDetail.ProductID;
            updateOrderDetailVM.Quantity = orderDetail.Quantity;
            updateOrderDetailVM.Unit = orderDetail.Unit;
            updateOrderDetailVM.UnitPrice = orderDetail.UnitPrice;
            updateOrderDetailVM.TotalPrice = orderDetail.TotalPrice;
            UpdateOrderDetailPageVM uodpVm = new UpdateOrderDetailPageVM();
            uodpVm.UpdateOrderDetailVM = updateOrderDetailVM;
            return View(uodpVm);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetail(UpdateOrderDetailPageVM model)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.OrderID = model.UpdateOrderDetailVM.OrderID;
            orderDetail.ProductID = model.UpdateOrderDetailVM.OrderID;
            orderDetail.Quantity = model.UpdateOrderDetailVM.Quantity;
            orderDetail.Unit = model.UpdateOrderDetailVM.Unit;
            orderDetail.UnitPrice = model.UpdateOrderDetailVM.UnitPrice;
            orderDetail.TotalPrice = model.UpdateOrderDetailVM.TotalPrice;
            await _orderDetailManager.UpdateAsync(orderDetail);
            return RedirectToAction("GetOrderDetails");
        }
        
    }

}
