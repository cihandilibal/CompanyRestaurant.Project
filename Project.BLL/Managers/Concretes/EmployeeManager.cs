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
    public class EmployeeManager:BaseManager<Employee>, IEmployeeManager
    {
        readonly IEmployeeRepository _eRep;
        public EmployeeManager(IEmployeeRepository eRep):base(eRep)
        {
            _eRep = eRep;
        }
    }
}
