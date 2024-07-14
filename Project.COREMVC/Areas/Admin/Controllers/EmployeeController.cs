using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.COREMVC.Areas.Admin.Models.Employees.ResponseModels;
using Project.COREMVC.Areas.Admin.Models.Employees.PageVMs;
using Project.ENTITIES.Models;
using Project.BLL.Managers.Concretes;


namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        public IActionResult ListEmployees()
        {
            List<ListEmployeesResponseModel> employees = _employeeManager.Select(x => new ListEmployeesResponseModel
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Duty = x.Duty,
                MobilePhone = x.MobilePhone,
                Address = x.Address,
                OffNumber = x.OffNumber,
                OffTime = x.OffTime,
                Status = x.Status
            }).ToList();
            ListEmployeePageVM lepVm = new ListEmployeePageVM()
            {
                Employees = employees
            };
            return View(lepVm);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeePageVM model)
        {
            Employee e = new()
            {
                FirstName = model.AddEmployeeRequestModel.FirstName,
                LastName = model.AddEmployeeRequestModel.LastName,
                Duty = model.AddEmployeeRequestModel.Duty,
                MobilePhone = model.AddEmployeeRequestModel.MobilePhone,
                Address = model.AddEmployeeRequestModel.Address,
                OffNumber = model.AddEmployeeRequestModel.OffNumber,
                OffTime = model.AddEmployeeRequestModel.OffTime
            };
            await _employeeManager.AddAsync(e);
            return RedirectToAction("ListEmployees");
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Calısan bulunamadı";
                return RedirectToAction("ListEmployees");
            }
            else
            {
                _employeeManager.Delete(await _employeeManager.FindAsync(id));
                return RedirectToAction("ListEmployees");
            }
        }

        public async Task<IActionResult> DestroyEmployee(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Calısan bulunamadı";
                return RedirectToAction("ListEmployees");
            }
            else
            {
                _employeeManager.Destroy(await _employeeManager.FindAsync(id));
                return RedirectToAction("ListEmployees");
            }
        }

        public async Task<IActionResult> UpdateEmployee(int id)
        {
            Employee employee = await _employeeManager.FindAsync(id);
            UpdateEmployeeVM updateEmployeeVM = new UpdateEmployeeVM();
            updateEmployeeVM.ID = employee.ID;
            updateEmployeeVM.FirstName = employee.FirstName;
            updateEmployeeVM.LastName = employee.LastName;
            updateEmployeeVM.Duty = employee.Duty;
            updateEmployeeVM.MobilePhone = employee.MobilePhone;
            updateEmployeeVM.Address = employee.Address;
            updateEmployeeVM.OffNumber = employee.OffNumber;
            updateEmployeeVM.OffTime = employee.OffTime;
            UpdateEmployeePageVM uepVm = new UpdateEmployeePageVM();
            uepVm.UpdateEmployeeVM = updateEmployeeVM;
            return View(uepVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeePageVM model)
        {
            Employee employee = new Employee();
            employee.ID = model.UpdateEmployeeVM.ID;
            employee.FirstName = model.UpdateEmployeeVM.FirstName;
            employee.LastName = model.UpdateEmployeeVM.LastName;
            employee.Duty = model.UpdateEmployeeVM.Duty;
            employee.MobilePhone = model.UpdateEmployeeVM.MobilePhone;
            employee.Address = model.UpdateEmployeeVM.Address;
            employee.OffNumber = model.UpdateEmployeeVM.OffNumber;
            employee.OffTime = model.UpdateEmployeeVM.OffTime;
            await _employeeManager.UpdateAsync(employee);
            return RedirectToAction("ListEmployees");
        }
    }
}
