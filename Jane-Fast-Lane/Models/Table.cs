using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jane_Fast_Lane.Models
{
    public class Table
    {
        public int Id { get; set; }

        [Display(Name = "Номер")]
        public int Number { get; set; }
        [Display(Name = "Капацитет")]
        public string Capacity { get; set; }
        [Display(Name = "Характеристики")]
        public string Characteristics { get; set; }
        public int SeatsTaken { get; set; }
        public string? CustomerId { get; set; }
        public ApplicationUser? Customer { get; set; }
        public string? WaiterId { get; set; }
        public ApplicationUser? Waiter { get; set; }
    }
}
