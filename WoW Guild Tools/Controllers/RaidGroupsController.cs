using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WoW_Guild_Tools.Data;
using WoW_Guild_Tools.Models;

namespace WoW_Guild_Tools.Controllers
{
    public class RaidGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaidGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RaidGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.RaidGroups.ToListAsync());
        }

        // GET: RaidGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raidGroup = await _context.RaidGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raidGroup == null)
            {
                return NotFound();
            }

            return View(raidGroup);
        }

        // GET: RaidGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RaidGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Published,RaidDay,LastUpdated")] RaidGroup raidGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raidGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raidGroup);
        }

        // GET: RaidGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raidGroup = await _context.RaidGroups.FindAsync(id);
            if (raidGroup == null)
            {
                return NotFound();
            }
            return View(raidGroup);
        }

        // POST: RaidGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Published,RaidDay,LastUpdated")] RaidGroup raidGroup)
        {
            if (id != raidGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raidGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaidGroupExists(raidGroup.Id))
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
            return View(raidGroup);
        }

        // GET: RaidGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raidGroup = await _context.RaidGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raidGroup == null)
            {
                return NotFound();
            }

            return View(raidGroup);
        }

        // POST: RaidGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raidGroup = await _context.RaidGroups.FindAsync(id);
            _context.RaidGroups.Remove(raidGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaidGroupExists(int id)
        {
            return _context.RaidGroups.Any(e => e.Id == id);
        }
    }
}
