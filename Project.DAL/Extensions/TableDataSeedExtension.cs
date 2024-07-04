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
    public static class TableDataSeedExtension
    {
        public static void SeedTables(ModelBuilder modelBuilder)
        {
            List<Table> tables = new();

            for (int i = 1; i < 11; i++)
            {
                Table t = new()
                {
                    ID = i,
                    TableNo = 2,
                    Status = "Rezerve",
                };

                tables.Add(t);
            }

            modelBuilder.Entity<Table>().HasData(tables);
        }
    }
}
