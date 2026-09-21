using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFModelCreatedApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly? DateStart { get; set; }
        public DateOnly? DateFinish { get; set; } = null;
    }
}
