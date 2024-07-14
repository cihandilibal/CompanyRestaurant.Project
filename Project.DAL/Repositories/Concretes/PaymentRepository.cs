using Microsoft.EntityFrameworkCore;
using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class PaymentRepository: BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository (MyContext db): base(db)
        {
            
        }
        public async Task<List<Payment>> GetPaymentsAsync(DateTime startDate, DateTime endDate)
        {
            return await _db.Payments.Where(x => x.Date >= startDate && x.Date <= endDate).ToListAsync();
        }
    }
}
