using Microsoft.EntityFrameworkCore;
using NetEFModelCreatedApp;
using NetEFModelCreatedApp.Models;

using(ApplicationContext context = new())
{
    var employees = context.Employees
                           .Include(e => e.Company)
                                .ThenInclude(c => c.City)
                           .Include(e => e.Position);

    foreach (var e in employees)
        Console.WriteLine($"Name: {e.Name}, Company: {e.Company?.Title} ({e.Company?.City?.Title}), Position: {e.Position?.Title}");

    //var cities = context.Cities
    //                    .Include(c => c.Companies);

    //foreach(var c in cities)
    //{
    //    Console.WriteLine($"City Title: {c.Title}");
    //    foreach(var cmp in c.Companies)
    //        Console.WriteLine($"\tCompany Title: {cmp.Title}");
}
        

}