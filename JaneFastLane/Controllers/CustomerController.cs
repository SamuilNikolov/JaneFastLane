using JaneFastLane.Areas.Identity.Pages.Account;
using JaneFastLane.Data;
using JaneFastLane.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace JaneFastLane.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<LoginModel> _logger;
        public CustomerController(ApplicationDbContext context, UserManager<ApplicationUser> _userManager, ILogger<LoginModel> logger)
        {
            _context = context;
            userManager = _userManager;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            _logger.LogWarning("Cart amount of items1 => ");
            if (user.TableCustomerId!=null)
            {

                var table = await _context.Table
                    .Include(t => t.Waiter)
                    .Include(t => t.Characteristics)
                    .FirstOrDefaultAsync(m => m.Id == user.TableCustomerId);
                ViewData["Table"] = table;
                ViewData["User"] = user;
                var cart = new List<Menu>();
                foreach (var item in user.Cart.Split("|"))
                {
                    _logger.LogError("item => " + item);
                    int n;
                    if (int.TryParse(item, out n))
                    {
                        var menuItem = await _context.Menu.FirstOrDefaultAsync(i => i.Id == n);
                        cart.Add(menuItem);

                    }
                }
                ViewData["Cart"] = cart;
            }
            var applicationDbContext = _context.Menu.Include(m => m.Category);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Cart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            return View();
        }
        public async Task<IActionResult> AddToCart(int? id)
        {
            var menuItem = await _context.Menu.FirstOrDefaultAsync(i => i.Id == id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            user.Cart += "|"+menuItem.Id;
            await _context.SaveChangesAsync();
            await userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Customer");
        }
        public async Task<IActionResult> RemoveFromCart(int? id)
        {
            var menuItem = await _context.Menu.FirstOrDefaultAsync(i => i.Id == id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            var regex = new Regex(Regex.Escape("|"+menuItem.Id));
            user.Cart = regex.Replace(user.Cart, "", 1);
            await userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Customer");
        }

        public async Task<IActionResult> Order()
        {
            var order = new Order();
            order.OrderDate = DateTime.Now;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            order.ClientId = userId;
            var table = await _context.Table.Include(t=>t.Waiter).FirstOrDefaultAsync(m => m.Id == user.TableCustomerId);
            order.Table = table;
            order.WaiterId = table.WaiterId;
            order.OrderContent = user.Cart;
            user.Cart = "";
            _context.Order.Add(order);
            await userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Success", "Customer");
        }

        public async Task<IActionResult> RemoveOrder(int? id)
        {
            var order = await _context.Order.FirstOrDefaultAsync(o => o.Id == id);
            order.Status = "Returned";
            await _context.SaveChangesAsync();
            return RedirectToAction("Orders", "Customer");
        }
        public async Task<IActionResult> Orders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            var orders = await _context.Order.Include(o => o.Table.Characteristics).Where(o => o.ClientId == userId).ToListAsync();
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
            ViewData["OrdersAndContents"] = ordersAndContents;
            return View();
        }
        public async Task<IActionResult> Success()
        {
            return View();
        }
    }
}
