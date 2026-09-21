using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetEFWelcomeApp.Models;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");

var config = builder.Build();
var connectionString = config.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
var options = optionsBuilder.UseSqlServer(connectionString)
                            .Options;

using (ApplicationContext context = new())
{
    //Company yandex = new() { Title = "Yandex" };
    //Company rambler = new() { Title = "Rambler" };

    //Employee bob = new() { Name = "Bobby", Age = 28, Company = yandex };
    //Employee tom = new() { Name = "Tommy", Age = 32, Company = rambler };

    //context.Employees.Add(bob);
    //context.Employees.Add(tom);
    //context.SaveChanges();


    var employees = context.Employees
                           .ToList();

    foreach(var e in employees)
        Console.WriteLine($"Name: {e.Name}, Age: {e.Age}, Company: {e.Company?.Title}");
}






