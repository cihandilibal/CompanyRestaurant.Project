using Microsoft.Extensions.DependencyInjection;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class ManagerService
    {
       public static IServiceCollection AddManagerServices(this IServiceCollection services)
       {
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));

            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IAdditionManager, AdditionManager>();
            services.AddScoped<ITableManager, TableManager>();
            return services;
       }
    }
}
