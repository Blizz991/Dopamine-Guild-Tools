using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WoW_Guild_Tools.Data;
using WoW_Guild_Tools.Models;
using WoW_Guild_Tools.Models.Enums;
using WoW_Guild_Tools.Models.ViewModels;

namespace WoW_Guild_Tools.Controllers
{
    public class RosterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RosterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Roster
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Raiders.Include(r => r.Main).OrderBy(r => r.Class).ThenBy(r => r.Spec);
            return View(await applicationDbContext.ToListAsync());
        }

        //// GET: Roster/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var raider = await _context.Raiders
        //        .Include(r => r.Main)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (raider == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(raider);
        //}

        // GET: Roster/Create
        public async Task<IActionResult> Create(bool alt)
        {
            ViewResult view;

            if (!alt)
            {
                view = View();
            }
            else
            {
                var mainsRaiders = await _context.Raiders.FromSqlRaw<Raider>("exec GetMainRaiders").ToListAsync();

                view = View(
                    new CreateEditRaiderViewModel
                    {
                        Alt = alt,
                        MainRaiders = mainsRaiders
                    }
                );
            }

            return view;
        }

        // POST: Roster/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Race,Class,Spec,Role,Rank,Profession1,Profession2,MainId")] Raider raider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MainId"] = new SelectList(_context.Raiders, "Id", "Name", raider.MainId);
            return View(raider);
        }

        // GET: Roster/Edit/5
        public async Task<IActionResult> Edit(int? id, bool alt)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raider = await _context.Raiders.FindAsync(id);
            if (raider == null)
            {
                return NotFound();
            }

            var model = new CreateEditRaiderViewModel
            {
                Alt = alt,
                Raider = raider
            };

            if (alt)
            {
                var mainsRaiders = await _context.Raiders.FromSqlRaw<Raider>("exec GetMainRaiders").ToListAsync();
                model.MainRaiders = mainsRaiders;
            }

            return View(model);
        }

        // POST: Roster/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, bool alt, [Bind("Id,Name,Race,Class,Spec,Role,Rank,Profession1,Profession2,MainId")] Raider raider)
        {
            if (id != raider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {   
                try
                {
                    _context.Update(raider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaiderExists(raider.Id))
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
            
            return View(raider);
        }

        // GET: Roster/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raider = await _context.Raiders
                .Include(r => r.Main)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raider == null)
            {
                return NotFound();
            }

            return View(raider);
        }

        // POST: Roster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raider = await _context.Raiders.FindAsync(id);
            _context.Raiders.Remove(raider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaiderExists(int id)
        {
            return _context.Raiders.Any(e => e.Id == id);
        }
    }
}
