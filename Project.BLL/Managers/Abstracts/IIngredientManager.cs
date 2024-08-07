﻿using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
     public interface IIngredientManager:IManager<Ingredient>
     {
        decimal Cost();

        Task<string> ControlIngredient(int id);
     }

}
