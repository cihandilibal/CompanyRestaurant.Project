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
    public class CustomerManager:BaseManager<Customer>,ICustomerManager
    {
        readonly ICustomerRepository _cRep;
        public CustomerManager(ICustomerRepository cRep):base(cRep)
        {
            _cRep = cRep;
        }
    }
}
