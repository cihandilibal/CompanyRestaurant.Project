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
       Task<Dictionary<DateTime, Dictionary<string, decimal>>> GetDailyGiroAsync(DateTime startDate, DateTime endDate);
       Task<Dictionary<string, Dictionary<int, decimal>>> GetWeeklyGiroAsync(DateTime startDate, DateTime endDate);
       Task<Dictionary<string, Dictionary<string, decimal>>> GetMonthlyGiroAsync(DateTime startDate, DateTime endDate);



    }
}
