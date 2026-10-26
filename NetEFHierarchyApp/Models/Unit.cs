using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFHierarchyApp.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class InfantryUnit : Unit
    {
        public int Defence { get; set; }
    }

    public class ArcherUnit : Unit
    {
        public int Attack { get; set; }
    }

    public class CavalryUnit : Unit
    {
        public int Length { get; set; }
    }

    //public class MilitaryUnit : Unit
    //{

    //}

    //public class CivilUnit : Unit
    //{

    //}
}
