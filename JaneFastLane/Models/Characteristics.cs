using System.ComponentModel.DataAnnotations;

namespace JaneFastLane.Models
{
    public class Characteristics
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Za-z\s]{2,50}$", ErrorMessage = "От 2 до 50 латински букви с или без интервали.")]
        public string Characteristic { get; set; }
    }
}
