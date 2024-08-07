﻿using Project.BLL.Managers.Abstracts;
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
                cost += item.UnitPrice * item.ActualAmount; //malzeme satin alindiginda gerçek ile beklenen ayni.
            }
            return cost;
        }
       
        public async Task<string> ControlIngredient(int id)
        {
            Ingredient item = await _inRep.FindAsync(id);
            decimal difference = Math.Abs((item.ActualAmount - item.ExpectedAmount) /item.ExpectedAmount)*100;
            if (difference >= 20)
            {
                return "Uyarı: Stok Durumunu Kontrol Edin! ";
            }
            return "Stok Durumu Beklenilen Degerler Icinde";
        }

       
    }
}
