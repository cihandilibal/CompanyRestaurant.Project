using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Tables.RequestModels;
using Project.COREMVC.Models.Tables.ResponseModels;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Controllers
{
    public class TableController : Controller
    {
        readonly ITableManager _tableManager;
       
        public TableController (TableManager tableManager)
        {
            _tableManager = tableManager;
        }
        public IActionResult Tables()
        {
            return View(_tableManager.GetAll());
        }

        public IActionResult AddTable()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddTable(CreateTableRequestModel item)
        {
           Table t = new()
           { 
               TableNo = item.TableNo,
                Status = item.Status
           };
            await _tableManager.AddAsync(t);
            return RedirectToAction("Tables");
        }
        public async Task<IActionResult> DeleteTable(int id)
        {
            _tableManager.Delete(await _tableManager.FindAsync(id));
            return RedirectToAction("Tables");
        }
        public async Task<IActionResult> DestroyTable(int id)
        {
            _tableManager.Delete(await _tableManager.FindAsync(id));
            return RedirectToAction("Tables");

        }
        public async Task<IActionResult> UpdateTable(int id)
        {
            return View(await _tableManager.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTable(Table item)
        {
            await _tableManager.UpdateAsync(item);
            return RedirectToAction("Tables");

        }

    }
}
