using Microsoft.EntityFrameworkCore;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Extensions
{
    public static class EmployeeDataSeedExtension
    {
        public static void SeedEmployees(ModelBuilder modelBuilder)
        {
            List<Employee> employees = new();

            for (int i = 1; i < 11; i++)
            {
                Employee e = new()
                {
                    ID = i,
                    FirstName = "Batuhan",
                    LastName = "Dilibal",
                    Duty = "Garson",
                    MobilePhone = "0435 769 56 93",
                    Address = "Uskudar",
                    OffNumber = 3
                };

                employees.Add(e);
            }

            modelBuilder.Entity<Employee>().HasData(employees);
        }

    }
}
