﻿using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IPaymentRepository: IRepository<Payment>
    {
        Task<List<Payment>> GetPaymentsAsync(DateTime startDate, DateTime endDate);
    }
}
