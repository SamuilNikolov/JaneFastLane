using Jane_Fast_Lane.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jane_Fast_Lane.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {

        private readonly UserManager<ApplicationUser> userManager;
        public IActionResult AdminPanel()
        {
            var users = userManager.Users;
            return View(users);
        }
        public AdminController(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }

        public async Task<IActionResult> AssignWaiter(string id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
                await userManager.AddToRoleAsync(user, "Waiter");
            user.Role = "Waiter";
            await userManager.UpdateAsync(user);
            return RedirectToAction("AdminPanel","Admin");
        }

        public async Task<IActionResult> RemoveWaiter(string id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            var isInRole = await userManager.IsInRoleAsync(user, "Waiter");
            if (isInRole)
            {
                await userManager.RemoveFromRoleAsync(user, "Waiter");
                user.Role = "No Role";
                await userManager.UpdateAsync(user);
            }
            
            return RedirectToAction("AdminPanel", "Admin");
        }
        public async Task<IActionResult> AssignCustomer(string id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            await userManager.AddToRoleAsync(user, "Customer");
            user.Role = "Customer";
            await userManager.UpdateAsync(user);
            return RedirectToAction("AdminPanel", "Admin");
        }
        public async Task<IActionResult> RemoveCustomer(string id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            var isInRole = await userManager.IsInRoleAsync(user, "Customer");
            if (isInRole)
            {
                await userManager.RemoveFromRoleAsync(user, "Customer");
                user.Role = "No Role";
                await userManager.UpdateAsync(user);
            }
            return RedirectToAction("AdminPanel", "Admin");
        }
        public async Task<IActionResult> AssignAdmin(string id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            await userManager.AddToRoleAsync(user, "Administrator");
            user.Role = "Administrator";
            await userManager.UpdateAsync(user);
            return RedirectToAction("AdminPanel", "Admin");
        }

        public async Task<IActionResult> RemoveAdmin(string id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            var isInRole = await userManager.IsInRoleAsync(user, "Administrator");

            if (isInRole)
            {
                await userManager.RemoveFromRoleAsync(user, "Administrator");
                user.Role = "No Role";
                await userManager.UpdateAsync(user);
            }
            return RedirectToAction("AdminPanel", "Admin");
        }
    }
}
