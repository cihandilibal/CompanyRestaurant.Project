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

            services.AddScoped<IAdditionManager, AdditionManager>();
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IOrderManager,    OrderManager>();
            services.AddScoped<IOrderDetailManager, OrderDetailManager>();
            services.AddScoped<IPaymentManager, PaymentManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IRecipeManager, RecipeManager>();
            services.AddScoped<IIngredientManager, IngredientManager>();
            services.AddScoped<IRecipeDetailManager, RecipeDetailManager>();
            services.AddScoped<ITableManager, TableManager>();
            
            return services;
       }
    }
}
