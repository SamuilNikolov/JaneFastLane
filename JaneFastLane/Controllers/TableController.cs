using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JaneFastLane.Data;
using JaneFastLane.Models;
using Microsoft.AspNetCore.Identity;

namespace JaneFastLane.Controllers
{
    public class TableController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly RoleManager<IdentityRole> _roleManager;
        public TableController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        // GET: Table
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Table.Include(t => t.Customer).Include(t => t.Waiter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Table/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            var table = await _context.Table
                .Include(t => t.Customer)
                .Include(t => t.Waiter)
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
            ViewData["WaiterId"] = new SelectList(_context.Set<ApplicationUser>().Where(x => x.Role == "Waiter"), "Id", "UserName");
            return View();
        }

        // POST: Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Capacity,Characteristics,SeatsTaken,WaiterId")] Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WaiterId"] = new SelectList(_context.Set<ApplicationUser>().Where(x => x.Role == "Waiter"), "Id", "UserName", table.WaiterId);
            return View(table);
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
            ViewData["WaiterId"] = new SelectList(_context.Set<ApplicationUser>().Where(x => x.Role == "Waiter"), "Id", "UserName", table.WaiterId);
            return View(table);
        }

        // POST: Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Capacity,Characteristics,SeatsTaken,WaiterId")] Table table)
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
            ViewData["WaiterId"] = new SelectList(_context.Set<ApplicationUser>().Where(x => x.Role == "Waiter"), "Id", "UserName", table.WaiterId);
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
                .Include(t => t.Customer)
                .Include(t => t.Waiter)
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
