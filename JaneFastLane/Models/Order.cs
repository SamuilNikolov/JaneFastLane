using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JaneFastLane.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string WaiterId { get; set; }
        public Table Table { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int? RatingFood { get; set; } = 0;
        public int? RatingWaiter { get; set; } = 0;
        public string OrderContent { get; set; }
        public string Status { get; set; } = "Sent";
    }
}
