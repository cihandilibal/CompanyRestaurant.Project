using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class PaymentManager : BaseManager<Payment>, IPaymentManager
    {
        IPaymentRepository _paRep;

        public PaymentManager(IPaymentRepository paRep) : base(paRep)
        {
            _paRep = paRep;
        }
        

        public async Task<Dictionary<DateTime, Dictionary<string, decimal>>> GetDailyGiroAsync(DateTime startDate, DateTime endDate)
        {
            List<Payment> payments = await _paRep.GetPaymentsAsync(startDate, endDate);
            return payments.GroupBy(x => x.Date.Date).ToDictionary
                (
                g => g.Key,
                g => g
                .GroupBy(s => s.Currency).ToDictionary
                    (
                        g2 => g2.Key,
                        g2 => g2.Sum(s => s.Price)
                    ));
        }


        public async Task<Dictionary<string, Dictionary<int, decimal>>> GetWeeklyGiroAsync(DateTime startDate, DateTime endDate)
        {
           
            List<Payment> payments = await _paRep.GetPaymentsAsync(startDate,endDate);

            return  payments.GroupBy(x => new { x.Currency, Week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(x.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday) }).GroupBy(g => g.Key.Currency)
               .ToDictionary 
              (
               g => g.Key,
               g => g.ToDictionary (
                    weekGroup => weekGroup.Key.Week,
                    weekGroup => weekGroup.Sum(x => x.Price)));
        }

        public async Task<Dictionary<string, Dictionary<string, decimal>>> GetMonthlyGiroAsync(DateTime startDate, DateTime endDate)
        {
            List<Payment> payments = await _paRep.GetPaymentsAsync(startDate, endDate);

            return payments.GroupBy(x => new { x.Currency, YearMonth = $"{x.Date.Year}-{x.Date.Month.ToString("D2")}" }).GroupBy(g => g.Key.Currency).ToDictionary
               (
                 g => g.Key,
                 g => g.ToDictionary(
                monthGroup => monthGroup.Key.YearMonth,
                monthGroup => monthGroup.Sum(x => x.Price)));
        }

    }  
}
