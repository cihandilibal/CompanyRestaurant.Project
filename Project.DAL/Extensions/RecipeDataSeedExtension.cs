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
    public static class RecipeDataSeedExtension
    {
        public static void SeedRecipes(ModelBuilder modelBuilder)
        {
            List<Recipe> recipes = new();

            {
                Recipe r = new()
                {
                    ID = 1,
                    Name = "Filtre Kahve"
                };

                recipes.Add(r);
            }

            modelBuilder.Entity<Recipe>().HasData(recipes);
        }
    }
}
