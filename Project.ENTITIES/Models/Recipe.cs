using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Recipe: BaseEntity
    {
        public string Name { get; set; }
      
        //Relational Properties
        public virtual ICollection<RecipeDetail> RecipeIngredients { get; set; }

    }
}
