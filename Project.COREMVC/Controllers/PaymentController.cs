using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Payments.RequestModels;
using Project.COREMVC.Models.Payments.PageVMs;
using Project.COREMVC.Models.Payments.ResponseModels;
using Project.ENTITIES.Models;
using Project.COREMVC.Models.Ingredients.PageVMs;

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
        public async Task<IActionResult> CreatePayment(CreatePaymentPageVM item)
        {
            Payment pa = new()
            {
                Price = item.PaymentRequestModel.Price,
                Currency = item.PaymentRequestModel.Currency,
                Date = item.PaymentRequestModel.Date,
                PaymentMethod = item.PaymentRequestModel.PaymentMethod
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
            Payment payment = await _paymentManager.FindAsync(id);
            UpdatePaymentVM updatePaymentVM = new UpdatePaymentVM();
            updatePaymentVM.ID = payment.ID;
            updatePaymentVM.Price = payment.Price;
            updatePaymentVM.Currency = payment.Currency;
            updatePaymentVM.Date= payment.Date;
            updatePaymentVM.PaymentMethod= payment.PaymentMethod;
            UpdatePaymentPageVM uppVm = new UpdatePaymentPageVM();
            uppVm.UpdatePaymentVM = updatePaymentVM;
            return View(uppVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePayment(UpdatePaymentPageVM model)
        {
            Payment payment = new Payment();
            payment.ID = model.UpdatePaymentVM.ID;
            payment.Price = model.UpdatePaymentVM.Price;
            payment.Currency = model.UpdatePaymentVM.Currency;
            payment.Date = model.UpdatePaymentVM.Date;
            payment.PaymentMethod = model.UpdatePaymentVM.PaymentMethod;
            await _paymentManager.UpdateAsync(payment);
            return RedirectToAction("Index");
        }
    }
}
