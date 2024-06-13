using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;

namespace Project.COREMVC.Controllers
{
    
    public class CustomerController : Controller
    {
        readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
            
        public IActionResult CreateCustomer()
        {
            return View();
        }
        

        
    }
}
