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
    public static class RecipeDetailDataSeedExtension
    {
        public static void SeedRecipDetails(ModelBuilder modelBuilder)
        {
            List<RecipeDetail> recipeDetails = new();

            for (int i = 1; i < 11; i++)
            {
                RecipeDetail re = new()
                {
                    RecipeID = i,
                    IngredientID = i,
                    Instruction = "Karıstır",
                    IngredientQuantity = 3,
                    Unit = "Adet"
                };

                recipeDetails.Add(re);
            }

            modelBuilder.Entity<RecipeDetail>().HasData(recipeDetails);
        }
    }
}
