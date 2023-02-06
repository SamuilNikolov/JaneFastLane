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
using System.Security.Claims;

namespace JaneFastLane.Controllers
{
    public class TableController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public TableController(ApplicationDbContext context, UserManager<ApplicationUser> _userManager)
        {
            _context = context;
            userManager = _userManager;
        }


        [HttpGet]
        public async Task<IActionResult> SitOnTable(int id)
        {
            var table = await _context.Table
                .Include(t => t.Waiter)
                .FirstOrDefaultAsync(m => m.Id == id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            table.Customers.Append(user);
            user.TableCustomer = table;
            table.SeatsTaken++;
            await _context.SaveChangesAsync();

            var applicationDbContext = _context.Table.Include(t => t.Waiter);
            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public async Task<IActionResult> LeaveTable(int id)
        {
            var table = await _context.Table
                .Include(t => t.Waiter)
                .FirstOrDefaultAsync(m => m.Id == id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            table.Customers = table.Customers.Where(t => t.Id != userId);
            user.TableCustomer = null;
            table.SeatsTaken--;
            await _context.SaveChangesAsync();

            var applicationDbContext = _context.Table.Include(t => t.Waiter);
            return RedirectToAction("Index", "Home");
        }

        // GET: Table
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Table.Include(t => t.Waiter)
                .Include(t => t.Characteristics);
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
                .Include(t => t.Characteristics)
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
            ViewData["CharacteristicsId"] = new SelectList(_context.Set<Characteristics>(), "Id", "Characteristic");
            ViewData["WaiterId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "UserName");
            return View();
        }

        // POST: Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Capacity,CharacteristicsId,SeatsTaken,WaiterId")] Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacteristicsId"] = new SelectList(_context.Set<Characteristics>(), "Id", "Characteristic", table.CharacteristicsId);
            ViewData["WaiterId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "UserName", table.WaiterId);
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
            ViewData["CharacteristicsId"] = new SelectList(_context.Set<Characteristics>(), "Id", "Characteristic", table.CharacteristicsId);
            ViewData["WaiterId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "UserName", table.WaiterId);
            return View(table);
        }

        // POST: Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Capacity,CharacteristicsId,SeatsTaken,WaiterId")] Table table)
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
            ViewData["CharacteristicsId"] = new SelectList(_context.Set<Characteristics>(), "Id", "Characteristic", table.CharacteristicsId);
            ViewData["WaiterId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "UserName", table.WaiterId);
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
