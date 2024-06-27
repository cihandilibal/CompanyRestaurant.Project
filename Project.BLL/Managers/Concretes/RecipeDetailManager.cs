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
    
    public class RecipeDetailManager: BaseManager<RecipeDetail>, IRecipeDetailManager
    {
        readonly IRecipeDetailRepository _reRep;

        public RecipeDetailManager(IRecipeDetailRepository reRep):base(reRep)
        {
            _reRep = reRep;
        }
    }
}
