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
            
        public IActionResult Index()
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
                
                Name = item.Name,
                LastName = item.LastName,
                MobileNo = item.MobileNo
            };
            await _customerManager.AddAsync(c);
            return RedirectToAction("Index");
        }
       
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            return View(await _customerManager.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer()
        {
            

        }

       

    }
}
