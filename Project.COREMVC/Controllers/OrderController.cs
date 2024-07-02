using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.ENTITIES.Models;
using Project.COREMVC.Models.Orders.RequestModels;


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
            return View(_orderManager.GetActives());
        }
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequestModel model)
        {
            Order o = new()
            {

                TableNo = model.TableNo,
                OrderTime = model.OrderTime,
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
            return View(await _orderManager.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order item)
        {
            await _orderManager.UpdateAsync(item);
            return RedirectToAction("ListOrders");
        }
       

       

    }
}
