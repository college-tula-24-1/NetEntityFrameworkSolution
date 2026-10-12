using Microsoft.EntityFrameworkCore;
using NetEFModelCreatedApp;
using NetEFModelCreatedApp.Models;

using(ApplicationContext context = new())
{
    //var cities = context.Cities.ToList();
    //foreach(var c in cities)
    //    Console.WriteLine(c.Title);

    var companies = context.Companies
                           .Include(c => c.City)
                           .Include(c => c.Employees)
                           .ToList();

    foreach (var c in companies)
    {
        Console.WriteLine($"Company Title: {c.Title}, City: {c.City?.Title}");
        foreach(var e in c.Employees)
            Console.WriteLine($"\t{e.Name}");
    }
        


    //var emploees = context.Employees
    //                      .Include(e => e.Company)
    //                        .ThenInclude(c => c.City)
    //                      .Include(e => e.Position);
    //foreach (var e in emploees)
    //    Console.WriteLine(@$"Name: {e.Name}, 
    //    Company: {e.Company?.Title}, 
    //    City: {e.Company?.City?.Title},
    //    Position: {e.Position?.Title}");
}