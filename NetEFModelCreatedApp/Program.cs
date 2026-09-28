using Microsoft.EntityFrameworkCore;
using NetEFModelCreatedApp.Models;

using(ApplicationContext context = new())
{
    City moscow = new() { Title = "Moscow" };
    City kazan = new() { Title = "Kazan" };
    City petersburg = new() { Title = "St Petersburg" };

    Company yandex = new() { Title = "Yandex", City = moscow };
    Company piterSoft = new() { Title = "Piter Soft", City = petersburg };
    Company tatarSoft = new() { Title = "Tatar Soft", City = kazan };
    Company mailGroup = new() { Title = "Mail Group", City = moscow };
    Company amigo = new() { Title = "Amigo", City = petersburg };

    context.Cities.AddRange([moscow, kazan, petersburg]);
    context.Companies.AddRange([yandex, piterSoft, tatarSoft, mailGroup, amigo]);

    context.SaveChanges();

    var cities = context.Cities
                        .ToList();

    Console.WriteLine("Cities:");
    foreach(var c in cities)
    {
        Console.WriteLine(c.Title);
        foreach(var comp in c.Companies)
            Console.WriteLine($"\t{comp.Title}");
    }
        
    Console.WriteLine();

    Console.WriteLine("Companies:");
    foreach (var c in context.Companies)
        Console.WriteLine($"{c.Title} {c.City?.Title}");
    Console.WriteLine();
}