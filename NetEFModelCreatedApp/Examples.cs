using NetEFModelCreatedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFModelCreatedApp
{
    public static class Examples
    {
        public static async Task InsertData(ApplicationContext context)
        {
            List<City> cities = new()
            {
                new(){ Title = "Kazan" },
                new(){ Title = "Moscow" },
                new(){ Title = "St Petersburg" }
            };

            List<Company> companies = new()
            {
                new(){ Title = "ComLine", City = cities[0] },
                new(){ Title = "LaCoNix", City = cities[0] },
                new(){ Title = "CityCom", City = cities[0] },

                new(){ Title = "Yandex", City = cities[1] },
                new(){ Title = "Ozon", City = cities[1] },
                new(){ Title = "Avito", City = cities[1] },
                new(){ Title = "Rambler", City = cities[1] },
                new(){ Title = "Mail Group", City = cities[1] },

                new(){ Title = "Iconica", City = cities[2] },
                new(){ Title = "PeterSoft", City = cities[2] },
                new(){ Title = "Trinet Group", City = cities[2] },
                new(){ Title = "Digital Design", City = cities[2] },
            };

            List<Position> positions = new()
    {
        new(){ Title = "Manager" },
        new(){ Title = "Team Leader" },
        new(){ Title = "Developer" },
        new(){ Title = "Tester" },
        new(){ Title = "DevOps" },
    };

            List<Employee> employees = new()
    {
        new()
        {
            Name = "Sammy",
            BirthDate = DateOnly.FromDateTime(new DateTime(2001, 11, 5)),
            Company = companies[0],
            Position = positions[0]
        },
        new()
        {
            Name = "Jimmy",
            BirthDate = DateOnly.FromDateTime(new DateTime(1998, 5, 21)),
            Company = companies[1],
            Position = positions[2]
        },
        new()
        {
            Name = "Poppy",
            BirthDate = DateOnly.FromDateTime(new DateTime(2002, 3, 25)),
            Company = companies[4],
            Position = positions[3]
        },
        new()
        {
            Name = "Jimmy",
            BirthDate = DateOnly.FromDateTime(new DateTime(1996, 08, 14)),
            Company = companies[5],
            Position = positions[2]
        },
        new()
        {
            Name = "Vinny",
            BirthDate = DateOnly.FromDateTime(new DateTime(2000, 8, 28)),
            Company = companies[0],
            Position = positions[3]
        }
    };

            await context.Cities.AddRangeAsync(cities);
            await context.Companies.AddRangeAsync(companies);
            await context.Positions.AddRangeAsync(positions);
            await context.Employees.AddRangeAsync(employees);

            await context.SaveChangesAsync();
        }
    }
}
