using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JaneFastLane.Models
{
    public class Category
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Za-z\s]{2,50}$", ErrorMessage = "От 2 до 50 латински букви с или без интервали.")]
        public string Name { get; set; }

    }
}
