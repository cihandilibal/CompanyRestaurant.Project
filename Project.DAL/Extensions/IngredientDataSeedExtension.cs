using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Extensions
{
    public static class IngredientDataSeedExtension
    {
        public static void SeedIngredients(ModelBuilder modelBuilder)
        {
            List<Ingredient> ingredients = new();

            for (int i = 1; i < 11; i++)
            {
                Ingredient ing = new()
                {
                   ID = i,
                   Name = "Patates",
                   Amount = 10,
                   Unit = "kg",
                   PredictedAmount = 9
                   
                };
                   ingredients.Add(ing);
            }

            modelBuilder.Entity<Ingredient>().HasData(ingredients);
        }
    }
}
