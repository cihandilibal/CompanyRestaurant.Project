using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.Payments.RequestModels;
using Project.COREMVC.Models.Payments.PageVMs;
using Project.COREMVC.Models.Payments.ResponseModels;
using Project.ENTITIES.Models;
using System.Collections.Generic;


namespace Project.COREMVC.Controllers
{
    public class PaymentController : Controller
    {
        readonly IPaymentManager _paymentManager;
        
        private Dictionary<DateTime, Dictionary<string, decimal>> dailyGiro;
        private Dictionary<string, Dictionary<int, decimal>> weeklyGiro;
        private Dictionary<string, Dictionary<string, decimal>> monthlyGiro;

        public PaymentController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }
        public IActionResult Index(DateTime date)
        {
            List<PaymentResponseModel> payments = _paymentManager.Select(x => new PaymentResponseModel
            {
                ID = x.ID,
                OrderNo = x.OrderNo,
                Price = x.Price,
                Currency = x.Currency,
                Date = x.Date,
                Status = x.Status

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
                OrderNo = item.PaymentRequestModel.OrderNo,
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
            if (id == null)
            {
                TempData["Message"] = "Odeme bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                _paymentManager.Delete(await _paymentManager.FindAsync(id));
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DestroyPayment(int id)
        {
            if (id == null)
            {
                TempData["Message"] = "Odeme bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                _paymentManager.Destroy(await _paymentManager.FindAsync(id));
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> UpdatePayment(int id)
        {
            Payment payment = await _paymentManager.FindAsync(id);
            UpdatePaymentVM updatePaymentVM = new UpdatePaymentVM();
            updatePaymentVM.ID = payment.ID;
            updatePaymentVM.OrderNo = payment.OrderNo;
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
            payment.OrderNo = model.UpdatePaymentVM.OrderNo;
            payment.Price = model.UpdatePaymentVM.Price;
            payment.Currency = model.UpdatePaymentVM.Currency;
            payment.Date = model.UpdatePaymentVM.Date;
            payment.PaymentMethod = model.UpdatePaymentVM.PaymentMethod;
            await _paymentManager.UpdateAsync(payment);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DailyReport(DateTime startDate, DateTime endDate)
        {
            dailyGiro = await _paymentManager.GetDailyGiroAsync(startDate, endDate);

            return View(dailyGiro);
        }

        public async Task<IActionResult> WeeklyReport(DateTime startDate, DateTime endDate)
        {
            weeklyGiro = await _paymentManager.GetWeeklyGiroAsync(startDate, endDate);

            return View(weeklyGiro);
        }

        public async Task<IActionResult> MonthlyReport(DateTime startDate, DateTime endDate)
        {
            monthlyGiro = await _paymentManager.GetMonthlyGiroAsync(startDate, endDate);

            return View(monthlyGiro);
        }

    }


}
