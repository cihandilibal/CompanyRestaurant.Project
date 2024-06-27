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
    public class IngredientManager : BaseManager<Ingredient>, IIngredientManager
    {
        readonly IIngredientRepository _inRep;
        public IngredientManager(IIngredientRepository inRep) : base(inRep)
        {
            _inRep = inRep;
        }

        public decimal Cost()
        {
            decimal cost = 0;
            List<Ingredient> ingredients = _inRep.GetActives();
            foreach (Ingredient item in ingredients)
            {
                cost += item.UnitPrice * item.Amount;
            }
            return cost;
        }
        
    }
}
