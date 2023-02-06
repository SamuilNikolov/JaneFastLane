using JaneFastLane.Data;
using JaneFastLane.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.Security.Claims;

namespace JaneFastLane.Controllers
{
    public class WaiterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        public WaiterController(ApplicationDbContext context, UserManager<ApplicationUser> _userManager)
        {
            _context = context;
            userManager = _userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            var tables = await _context.Table.Include(t => t.Waiter)
                .Include(t => t.Characteristics).Where(t=>t.WaiterId==userId).ToListAsync();
            var orders = await _context.Order.Include(t => t.Table).Where(t => t.WaiterId == userId).Where(o => o.Status =="Sent").ToListAsync();
            var contents = new List<List<Menu>>();
            foreach (var order in orders)
            {
                var cart = new List<Menu>();
                foreach (var item in order.OrderContent.Split("|"))
                {
                    if (int.TryParse(item, out int n))
                    {
                        var menuItem = await _context.Menu.FirstOrDefaultAsync(i => i.Id == n);
                        cart.Add(menuItem);

                    }
                }
                contents.Add(cart);
            }
            var ordersAndContents = orders.Zip(contents);

            ViewData["Tables"] = tables;
            ViewData["OrdersAndContents"] = ordersAndContents;
            return View();
        }

        public async Task<IActionResult> FinishOrder(int? id)
        {
            var order = await _context.Order.FirstOrDefaultAsync(o=> o.Id == id);
            order.Status = "Finished";
            order.CompletionDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Waiter");
        }
    }
}
