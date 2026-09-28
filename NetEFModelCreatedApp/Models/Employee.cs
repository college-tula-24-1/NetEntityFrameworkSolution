using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFModelCreatedApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        //[MaxLength(50)]
        public string Name { get; set; } = null!;
        public DateOnly? BirthDate { get; set; }
        public Company? Company { get; set; }
        public Position? Position { get; set; }
        public decimal? Salary { get; set; }
    }
}
