using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JaneFastLane.Models
{
    public class Order
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Za-z\s]{2,50}$", ErrorMessage = "От 2 до 50 латински букви с или без интервали.")]
        public string Name { get; set; }
        public string ClientId { get; set; }
        public string WaiterId { get; set; }
        public Table Table { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public int RatingFood { get; set; }
        public int RatingWaiter { get; set; }
    }
}
