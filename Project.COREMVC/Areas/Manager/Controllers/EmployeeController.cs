using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Areas.Manager.Models.Employees.RequestModels;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]

    public class EmployeeController : Controller
    {
        readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        public IActionResult GetEmployees()
        {
            return View(_employeeManager.GetAll());
        }
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeRequestModel model)
        {
            Employee e = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Duty = model.Duty,
                MobilePhone = model.MobilePhone,
                Address = model.Address,
                OffNumber = model.OffNumber
            };
            await _employeeManager.AddAsync(e);
            return RedirectToAction("GetEmployees");
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _employeeManager.Delete(await _employeeManager.FindAsync(id));
            return RedirectToAction("GetEmployees");
        }
        public async Task<IActionResult> DestroyEmployee(int id)
        {
            _employeeManager.Destroy(await _employeeManager.FindAsync(id));
            return RedirectToAction("GetEmployees");
        }
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            return View(await _employeeManager.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await _employeeManager.UpdateAsync(employee);
            return RedirectToAction("GetEmployees");
        }


    }
}
