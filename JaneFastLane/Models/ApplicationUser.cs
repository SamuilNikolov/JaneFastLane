using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JaneFastLane.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
        public IEnumerable<Table>? TablesWaiter { get; set; }
        public int? TableCustomerId { get; set; }
        public Table? TableCustomer { get; set; }
        public string? Cart { get; set; } = "";

    }
}
