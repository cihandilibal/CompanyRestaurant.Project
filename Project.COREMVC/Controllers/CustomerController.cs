using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Customers.RequestModels;
using Project.COREMVC.Models.Customers.ResponseModels;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Controllers
{
    
    public class CustomerController : Controller
    {
        readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
            
        public IActionResult GetCustomers()
        {
            return View(_customerManager.GetAll());
        }
        
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]

        public async Task <IActionResult> CreateCustomer(CreateCustomerRequestModel item)
        {
            Customer c = new()
            {
                
                FirstName = item.FirstName,
                LastName = item.LastName,
                MobilePhone = item.MobilePhone
            };
            await _customerManager.AddAsync(c);
            return RedirectToAction("GetCustomers");
        }
       
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            _customerManager.Delete(await _customerManager.FindAsync(id));
            return RedirectToAction("GetCustomers");
        }
        public async Task<IActionResult> DestroyCustomer(int id)
        {
           _customerManager.Destroy(await _customerManager.FindAsync(id));
            return RedirectToAction("GetCustomers");
        }

        public async Task<IActionResult> UpdateCustomer(int id)
        {
            return View(await _customerManager.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            await _customerManager.UpdateAsync(customer);
            return RedirectToAction("Index");
        }



    }
}
