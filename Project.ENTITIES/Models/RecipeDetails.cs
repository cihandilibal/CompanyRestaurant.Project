using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class RecipeDetail: BaseEntity
    {
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public string Instruction { get; set; }
        public decimal IngredientQuantity { get; set; }
        public string Unit { get; set; }
      
        //Relational Properties
        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient  { get; set; }

    }
}
