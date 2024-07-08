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
    public class TableManager: BaseManager<Table>, ITableManager
    {
        readonly ITableRepository _tRep;
        public TableManager(ITableRepository tRep):base(tRep)
        {
            _tRep = tRep;
        }
        
    }   
}
