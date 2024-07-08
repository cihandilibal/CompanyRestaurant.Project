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

            foreach (Ingredient item in _inRep.GetActives())
            {
                cost += item.UnitPrice * item.Amount;
            }
            return cost;
        }
       
        public string ControlIngredient(int id)
        {
            Ingredient item = _inRep.Find(id);
            decimal difference = Math.Abs((item.Amount - item.PredictedAmount) /item.Amount);
            if (difference == 0.2M)
            {
                return "Uyarı: Stok Durumunu Kontrol Edin! ";
            }
            return "Stok yeterli seviyede";
        }
        

    }
}
