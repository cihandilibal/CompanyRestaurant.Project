using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class PaymentManager: BaseManager<Payment>, IPaymentManager
    {
        IPaymentRepository _paRep;

        public PaymentManager(IPaymentRepository paRep): base(paRep)
        {
            _paRep = paRep;
        }
        public decimal GetDailyGiro(DateTime date)
        {
            decimal dailyGiro = _paRep.Where(x => x.Date == DateTime.Today).Sum(x => x.Price);
            return dailyGiro;
        }

        public decimal GetWeeklyGiro(DateTime startOfWeek)
        {
            DateTime endOfWeek = startOfWeek.AddDays(7);
            decimal weeklyGiro = _paRep.Where(x => x.Date >= startOfWeek && x.Date < endOfWeek).Sum(x => x.Price);
            return weeklyGiro;
        }
        public decimal GetMonthlyGiro(int year, int month)
        {
            decimal monthlyGiro = _paRep.Where(x => x.Date.Year == year && x.Date.Month == month).Sum(x => x.Price);
            return monthlyGiro;
        }
    }
}
