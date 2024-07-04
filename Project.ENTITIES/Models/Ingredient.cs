using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Ingredient: BaseEntity
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public int PredictedAmount { get; set; }
        public string Unit { get; set; }

        //Relational Properties
        public virtual ICollection<RecipeDetail> RecipeIngredients { get; set; }


    }
}
