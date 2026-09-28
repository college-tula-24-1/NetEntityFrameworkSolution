using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFModelCreatedApp.Models
{
    //[Index("Title")]
    public class City
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public List<Company> Companies { get; set; } = new();
    }
}
