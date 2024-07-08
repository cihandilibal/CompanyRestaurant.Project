using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Tables.PageVMs;
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
        public IActionResult Index()
        {
            List<TableResponseModel> tables;
            tables = _tableManager.Select(x => new TableResponseModel
            {
                ID = x.ID,
                TableNo = x.TableNo,
                Status = x.Status
            }).ToList();
            GetTablesPageVM gtpVm = new GetTablesPageVM()
            {
                Tables = tables
            };
            return View(gtpVm);

        }

        public IActionResult AddTable()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddTable(AddTablePageVM item)
        {
           Table t = new()
           { 
               TableNo = item.CreateTableRequestModel.TableNo,
                Status = item.CreateTableRequestModel.Status
           };
            await _tableManager.AddAsync(t);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTable(int id)
        {
            _tableManager.Delete(await _tableManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DestroyTable(int id)
        {
            _tableManager.Delete(await _tableManager.FindAsync(id));
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> UpdateTable(int id)
        {
            Table table = await _tableManager.FindAsync(id);
            UpdateTableVM updateTableVM = new UpdateTableVM();
            updateTableVM.ID = table.ID;
            updateTableVM.TableNo = table.TableNo;
            updateTableVM.Status = table.Status;
            UpdateTablePageVM utpVm = new UpdateTablePageVM();
            utpVm.UpdateTableVM = updateTableVM;
            return View(utpVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTable(UpdateTablePageVM model)
        {
            Table table = new Table();
            table.ID = model.UpdateTableVM.ID;
            table.TableNo = model.UpdateTableVM.TableNo;
            table.Status = model.UpdateTableVM.Status;
            await _tableManager.UpdateAsync(table);
            return RedirectToAction("Index");

        }

    }
}
