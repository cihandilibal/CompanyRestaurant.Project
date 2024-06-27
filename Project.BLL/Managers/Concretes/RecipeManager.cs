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
    public class RecipeManager: BaseManager<Recipe>, IRecipeManager
    {
       readonly IRecipeRepository _rRep;

        public RecipeManager(IRecipeRepository rRep) : base(rRep)
        {
            _rRep = rRep;
        }
    }
}
