using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JaneFastLane.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Za-z\s]{2,50}$", ErrorMessage = "От 2 до 50 латински букви с или без интервали.")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
