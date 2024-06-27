using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;

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

        public IActionResult Index()
        {
            return View(_employeeManager.GetAll());
        }
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateEmployee()
        {
            return View();
        }
    }
}
