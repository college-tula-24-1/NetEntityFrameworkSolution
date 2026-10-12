using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFModelCreatedApp.Models
{
    public class Passport
    {
        public string Series { get; set; } = null!;
        public string Number { get; set; } = null!;

        public Employee Employee { get; set; } = null!;
        public int EmployeeId { set; get; }

    }
}
