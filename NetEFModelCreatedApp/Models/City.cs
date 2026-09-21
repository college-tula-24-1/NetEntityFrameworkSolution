using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFModelCreatedApp.Models
{
    [NotMapped]
    public class City
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
