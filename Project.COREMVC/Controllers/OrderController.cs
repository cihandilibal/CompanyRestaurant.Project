using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.ENTITIES.Models;
using Project.COREMVC.Models.Orders.RequestModels;
using Project.COREMVC.Models.Orders.ResponseModels;
using Project.COREMVC.Models.Orders.PageVMs;


namespace Project.COREMVC.Controllers
{
    public class OrderController : Controller
    {
        readonly IOrderManager _orderManager;
       
        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
            
        }
        public IActionResult ListOrders()
        {
            List<ListOrdersResponseModel> orders;

            orders = _orderManager.Select(x => new ListOrdersResponseModel
            {
                ID = x.ID,
                TableNo = x.TableNo,
                OrderTime = x.OrderTime
            }).ToList();

            ListOrdersPageVM lopVm = new ListOrdersPageVM()
            {
                Orders = orders
            };
            return View(lopVm);
        }
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderPageVM model)
        {
            Order o = new()
            {

                TableNo = model.CreateOrderRequestModel.TableNo,
                OrderTime = model.CreateOrderRequestModel.OrderTime
            };

            await _orderManager.AddAsync(o);
            return RedirectToAction("ListOrders");
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            _orderManager.Delete(await _orderManager.FindAsync(id));
            return RedirectToAction("ListOrders");
        }
        public async Task<IActionResult> DestroyOrder(int id)
        {
            _orderManager.Destroy(await _orderManager.FindAsync(id));
            return RedirectToAction("ListOrders");
        }
        public async Task<IActionResult> UpdateOrder(int id)
        {
            Order order = await _orderManager.FindAsync(id);
            UpdateOrderVM updateOrderVM = new UpdateOrderVM();
            updateOrderVM.ID = order.ID;
            updateOrderVM.TableNo = order.TableNo;
            updateOrderVM.OrderTime = order.OrderTime;
            UpdateOrderPageVM uopVm= new UpdateOrderPageVM();
            uopVm.UpdateOrderVM = updateOrderVM;
            return View(uopVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderPageVM model)
        {
            Order order = new Order();
            order.ID = model.UpdateOrderVM.ID;
            order.TableNo = model.UpdateOrderVM.TableNo;
            order.OrderTime = model.UpdateOrderVM.OrderTime;
            await _orderManager.UpdateAsync(order);
            return RedirectToAction("ListOrders");
        }
       

       

    }
}
