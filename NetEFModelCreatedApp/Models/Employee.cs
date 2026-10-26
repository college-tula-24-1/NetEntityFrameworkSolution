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
        
        public string Name { get; set; } = null!;
        public DateOnly? BirthDate { get; set; }

        public Passport? Passport { get; set; }
        
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }

        public Position? Position { get; set; }
        public int? PositionId { get; set; }

        public decimal? Salary { get; set; }

        public List<Project> Projects { get; set; } = new();

        public List<ProjectEmployee> ProjectsEmployees { get; set; }
    }
}
