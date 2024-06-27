using Microsoft.AspNetCore.Mvc;

namespace Project.COREMVC.Controllers
{
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
