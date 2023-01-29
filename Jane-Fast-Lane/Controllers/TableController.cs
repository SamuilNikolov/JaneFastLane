using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jane_Fast_Lane.Data;
using Jane_Fast_Lane.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace Jane_Fast_Lane.Controllers
{
    public class TableController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public TableController(ApplicationDbContext context, RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager)
        {
            _context = context;
            roleManager = _roleManager;
            userManager = _userManager;
        }

        // GET: Table
        public async Task<IActionResult> Index()
        {
              return View(await _context.Table.ToListAsync());
        }

        // GET: Table/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            var table = await _context.Table
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }

        // GET: Table/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Capacity,Characteristics")] Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(table);
        }

        public async Task<ApplicationUser> GetUser()
        {
            var current_User = await userManager.GetUserAsync(HttpContext.User);
            return current_User;
        }

        // GET: Table/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            var table = await _context.Table.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        // POST: Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Capacity,Characteristics")] Table table)
        {
            if (id != table.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(table);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableExists(table.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(table);
        }

        // GET: Table/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            var table = await _context.Table
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }

        // POST: Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Table == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Table'  is null.");
            }
            var table = await _context.Table.FindAsync(id);
            if (table != null)
            {
                _context.Table.Remove(table);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableExists(int id)
        {
          return _context.Table.Any(e => e.Id == id);
        }
    }
}
