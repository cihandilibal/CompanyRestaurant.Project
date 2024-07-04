using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    public interface IPaymentManager: IManager<Payment>
    {
       decimal GetDailyGiro(DateTime date);
       decimal GetWeeklyGiro(DateTime startOfWeek);
       decimal GetMonthlyGiro(int year, int month);

    }
}
