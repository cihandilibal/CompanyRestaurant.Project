using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Customers.RequestModels;
using Project.COREMVC.Models.Customers.ResponseModels;
using Project.COREMVC.Models.Customers.PageVMs;
using Project.ENTITIES.Models;
using Project.COREMVC.Models.Categories.PageVMs;

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
            List<CustomerResponseModel> customers;
            customers = _customerManager.Select(x => new CustomerResponseModel
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MobilePhone = x.MobilePhone
            }).ToList();
            GetCustomersPageVM gvpVm = new GetCustomersPageVM()
            {
                Customers = customers
            };
            return View(gvpVm);
        }
        
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]

        public async Task <IActionResult> CreateCustomer(CreateCustomerPageVM item)
        {
            Customer c = new()
            {
                
                FirstName = item.CreateCustomerRequestModel.FirstName,
                LastName = item.CreateCustomerRequestModel.LastName,
                MobilePhone = item.CreateCustomerRequestModel.MobilePhone
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
            Customer customer = await _customerManager.FindAsync(id);
            UpdateCustomerVM updateCustomerVM = new UpdateCustomerVM();
            updateCustomerVM.ID = customer.ID;
            updateCustomerVM.FirstName = customer.FirstName;
            updateCustomerVM.LastName = customer.LastName;
            updateCustomerVM.MobilePhone = customer.MobilePhone;
            UpdateCustomerPageVM ucupVm = new UpdateCustomerPageVM();
            ucupVm.UpdateCustomerVM = updateCustomerVM;
            return View(ucupVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerPageVM model)
        {
            Customer customer = new Customer();
            customer.ID = model.UpdateCustomerVM.ID;
            customer.FirstName = model.UpdateCustomerVM.FirstName;
            customer.LastName = model.UpdateCustomerVM.LastName;
            customer.MobilePhone = model.UpdateCustomerVM.MobilePhone;
            await _customerManager.UpdateAsync(customer);
            return RedirectToAction("GetCustomers");
        }



    }
}
