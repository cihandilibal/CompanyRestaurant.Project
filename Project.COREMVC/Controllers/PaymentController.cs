using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Payments.RequestModels;
using Project.COREMVC.Models.Payments.PageVMs;
using Project.COREMVC.Models.Payments.ResponseModels;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Controllers
{
    public class PaymentController : Controller
    {
        readonly IPaymentManager _paymentManager;

        public PaymentController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }
        public IActionResult DailyReport(DateTime date)
        {
            decimal dailyGiro = _paymentManager.GetDailyGiro(date);
            ViewBag.Date = date;
            ViewBag.DailyGiro = dailyGiro;

            return View();
        }
        public IActionResult WeeklyReport(DateTime startOfWeek)

        {
            decimal weeklyGiro = _paymentManager.GetWeeklyGiro(startOfWeek);
            ViewBag.StartOfWeek = startOfWeek;
            ViewBag.WeeklyGiro = weeklyGiro;

            return View();
        }

        public IActionResult MonthlyReport(int year, int month)
        {
            decimal monthlyGiro = _paymentManager.GetMonthlyGiro(year, month);
            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.MonthlyGiro = monthlyGiro;
            return View();
        }

        public IActionResult Index()
        {
            List<PaymentResponseModel> payments = _paymentManager.Select(x => new PaymentResponseModel
            {
                ID = x.ID,
                Price = x.Price,
                Currency = x.Currency,
                Date = x.Date,
                OrderID = x.Order.ID
            }).ToList();
            PaymentsPageVM pVm = new PaymentsPageVM()
            {
                Payments = payments

            };
            return View(pVm);
        }
        public IActionResult CreatePayment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(PaymentRequestModel item)
        {
            Payment pa = new()
            {
                Price = item.Price,
                Currency = item.Currency,
                Date = item.Date,
                PaymentMethod = item.PaymentMethod
            };
            await _paymentManager.AddAsync(pa);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeletePayment(int id)
        {
            _paymentManager.Delete(await _paymentManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DestroyPayment(int id)
        {
            _paymentManager.Destroy(await _paymentManager.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdatePayment(int id)
        {
            return View(await _paymentManager.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePayment(Payment item)
        {
            await _paymentManager.UpdateAsync(item);
            return RedirectToAction("Index");
        }
    }
}
