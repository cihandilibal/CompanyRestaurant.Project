using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Areas.Manager.Models.Employees.PageVMs;
using Project.COREMVC.Areas.Manager.Models.Employees.RequestModels;
using Project.COREMVC.Areas.Manager.Models.Employees.ResponseModels;
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
            List<GetEmployeesResponseModel> employees = _employeeManager.Select(x => new GetEmployeesResponseModel
            {
                Id = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Duty = x.Duty,
                MobilePhone = x.MobilePhone,
                Address = x.Address,
                OffNumber = x.OffNumber
            }).ToList();
            GetEmployeesPageVM gepVm = new GetEmployeesPageVM()
            {
                Employees = employees
            };

            return View(gepVm);
        }
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeePageVM model)
        {
            Employee e = new Employee()
            {
                FirstName = model.CreateEmployeeRequestModel.FirstName,
                LastName = model.CreateEmployeeRequestModel.LastName,
                Duty = model.CreateEmployeeRequestModel.Duty,
                MobilePhone = model.CreateEmployeeRequestModel.MobilePhone,
                Address = model.CreateEmployeeRequestModel.Address,
                OffNumber = model.CreateEmployeeRequestModel.OffNumber
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
            Employee employee = await _employeeManager.FindAsync(id);
            UpdateEmployeeVM updateEmployeeVM = new UpdateEmployeeVM();
            updateEmployeeVM.ID= employee.ID;
            updateEmployeeVM.FirstName = employee.FirstName;
            updateEmployeeVM.LastName = employee.LastName;
            updateEmployeeVM.Duty = employee.Duty;
            updateEmployeeVM.Address = employee.Address;
            updateEmployeeVM.MobilePhone = employee.MobilePhone;
            updateEmployeeVM.OffNumber = employee.OffNumber;
            UpdateEmployeesPageVM uepVm = new UpdateEmployeesPageVM();
            uepVm.UpdateEmployeeVM = updateEmployeeVM;
            return View(uepVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeesPageVM model)
        {
            Employee employee = new Employee();
            employee.ID = model.UpdateEmployeeVM.ID;
            employee.FirstName = model.UpdateEmployeeVM.FirstName;
            employee.LastName = model.UpdateEmployeeVM.LastName;
            employee.Address = model.UpdateEmployeeVM.Address;
            employee.Duty = model.UpdateEmployeeVM.Duty;
            employee.MobilePhone = model.UpdateEmployeeVM.Duty;
            employee.OffNumber = model.UpdateEmployeeVM.OffNumber;
            await _employeeManager.UpdateAsync(employee);
            return RedirectToAction("GetEmployees");
        }
    }
}
