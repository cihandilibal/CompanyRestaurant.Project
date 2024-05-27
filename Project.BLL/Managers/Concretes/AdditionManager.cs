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
    public class AdditionManager: BaseManager<Addition>, IAdditionManager
    {
        readonly IAdditionRepository _additionRep;
        public AdditionManager(IAdditionRepository additionRep): base(additionRep)
        {
            _additionRep = additionRep;

        }


    }
}
