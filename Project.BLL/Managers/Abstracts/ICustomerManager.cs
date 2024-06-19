using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    public interface ICustomerManager : IManager<Customer>
    {
        Task UpdateAsync(Project.COREMVC.Models.ViewModels.CreateCustomerRequestModel customer);
        Task UpdateAsync(Project.COREMVC.Models.ViewModels.CreateCustomerRequestModel customer);
        Task UpdateRangeAsync(Project.COREMVC.Models.Customers.ResponseModels.CustomerResponseModel item);
    }
}
