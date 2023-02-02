using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JaneFastLane.Models
{
    public class Table
    {
        public Table()
        {
            this.Customers = new HashSet<ApplicationUser>();
        }
        public int Id { get; set; }

        [Display(Name = "Номер")]
        public int Number { get; set; }
        [Display(Name = "Капацитет")]
        public string Capacity { get; set; }
        [Display(Name = "Характеристики")]
        public string Characteristics { get; set; }
        public int SeatsTaken { get; set; }
        public IEnumerable<ApplicationUser>? Customers { get; set; }
        public string? WaiterId { get; set; }
        public ApplicationUser? Waiter { get; set; }
    }
}
