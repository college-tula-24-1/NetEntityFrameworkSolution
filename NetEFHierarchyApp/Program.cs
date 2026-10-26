using NetEFHierarchyApp.Models;

using (UnitDbContext context = new())
{
    Unit settlerUnit = new() { Name = "Settler" };
    InfantryUnit infantryUnit = new() { Name = "Infantry", Defence = 10 };
    ArcherUnit archerUnit = new() { Name = "Archer", Attack = 20 };
    CavalryUnit cavalryUnit = new() { Name = "Cavalry", Length = 5 };

    context.Units.Add(settlerUnit);
    context.Infantries.Add(infantryUnit);
    context.Archers.Add(archerUnit);
    context.Cavalries.Add(cavalryUnit);

    context.SaveChanges();
}