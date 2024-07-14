using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.ENTITIES.Models;
using Project.COREMVC.Models.Tables.ResponseModels;
using Project.COREMVC.Models.Tables.PageVMs;
using Project.BLL.Managers.Concretes;



namespace Project.COREMVC.Controllers
{
    public class TableController : Controller
    {
        readonly ITableManager _tableManager;
       
        public TableController (ITableManager tableManager)
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
                Situation = x.Situation,
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
        public async Task<IActionResult> AddTable(AddTablePageVM model)
        {
           Table t = new()
           { 
               TableNo = model.CreateTableRequestModel.TableNo,
               Situation = model.CreateTableRequestModel.Situation
           };
            await _tableManager.AddAsync(t);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTable(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Masa bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                _tableManager.Delete(await _tableManager.FindAsync(id));
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DestroyTable(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Masa bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                _tableManager.Destroy(await _tableManager.FindAsync(id));
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> UpdateTable(int id)
        {
            Table table = await _tableManager.FindAsync(id);
            UpdateTableVM updateTableVM = new UpdateTableVM();
            updateTableVM.ID = table.ID;
            updateTableVM.TableNo = table.TableNo;
            updateTableVM.Situation = table.Situation;
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
            table.Situation = model.UpdateTableVM.Situation;
            await _tableManager.UpdateAsync(table);
            return RedirectToAction("Index");

        }

    }
}
