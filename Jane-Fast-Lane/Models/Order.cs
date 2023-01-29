using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jane_Fast_Lane.Models
{
    public class Order
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Za-z\s]{2,50}$", ErrorMessage = "От 2 до 50 латински букви с или без интервали.")]
        public string Name { get; set; }

        public string Client { get; set; }

        public List<Menu> orderContent { get; set; }
    }
}
