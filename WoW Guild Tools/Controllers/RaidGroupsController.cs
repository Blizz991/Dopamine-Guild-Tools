using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WoW_Guild_Tools.Data;
using WoW_Guild_Tools.Models;
using WoW_Guild_Tools.Models.Enums;
using WoW_Guild_Tools.Models.ViewModels;

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
        public async Task<IActionResult> Create()
        {
            return View(await GetRosterCharacters());

            //return View(
            //    new RosterCharacters
            //    {
            //        Mains = new RoleRaiders
            //        {
            //            Tanks = new SingleRole
            //            {
            //                WowSpecRole = WowSpecRole.Tank,
            //                Raiders = new List<Raider>()
            //                {
            //                    new Raider
            //                    {
            //                        Name = "Blazzsham",
            //                        Class = WowClass.Shaman,
            //                        Spec = WowSpec.Elemental
            //                    },
            //                    new Raider
            //                    {
            //                        Name = "Néva",
            //                        Class = WowClass.Paladin,
            //                        Spec = WowSpec.Protection
            //                    }
            //                }
            //            },
            //            Healers = new SingleRole
            //            {
            //                WowSpecRole = WowSpecRole.Healer,
            //                Raiders = new List<Raider>()
            //                {
            //                    new Raider
            //                    {
            //                        Name = "Asd",
            //                        Class = WowClass.Shaman,
            //                        Spec = WowSpec.Elemental
            //                    },
            //                    new Raider
            //                    {
            //                        Name = "Néva",
            //                        Class = WowClass.Paladin,
            //                        Spec = WowSpec.Protection
            //                    }
            //                }
            //            }
            //        },
            //        Alts = new RoleRaiders
            //        {
            //            Tanks = new SingleRole
            //            {
            //                WowSpecRole = WowSpecRole.Tank,
            //                Raiders = new List<Raider>()
            //                {
            //                    new Raider
            //                    {
            //                        Name = "Blazzsham",
            //                        Class = WowClass.Shaman,
            //                        Spec = WowSpec.Elemental
            //                    },
            //                    new Raider
            //                    {
            //                        Name = "Néva",
            //                        Class = WowClass.Paladin,
            //                        Spec = WowSpec.Protection
            //                    }
            //                }
            //            }
            //        }
            //    }
            //);
            //return View();
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

        private async Task<RosterCharactersViewModel> GetRosterCharacters()
        {
            List<Raider> allRaiders = await _context.Raiders.ToListAsync();

            RosterCharactersViewModel rosterCharacters = new RosterCharactersViewModel
            {
                Mains = new RoleRaidersViewModel
                {
                    Title = "Mains",
                    Tanks = new SingleRoleViewModel
                    {
                        WowSpecRole = WowSpecRole.Tank,
                        Raiders = allRaiders.Where(r => r.IsAlt == false && r.Role == WowSpecRole.Tank).ToList()
                    },
                    Healers = new SingleRoleViewModel
                    {
                        WowSpecRole = WowSpecRole.Healer,
                        Raiders = allRaiders.Where(r => r.IsAlt == false && r.Role == WowSpecRole.Healer).ToList()
                    },
                    Melee = new SingleRoleViewModel
                    {
                        WowSpecRole = WowSpecRole.Melee,
                        Raiders = allRaiders.Where(r => r.IsAlt == false && r.Role == WowSpecRole.Melee).ToList()
                    },
                    Ranged = new SingleRoleViewModel
                    {
                        WowSpecRole = WowSpecRole.Ranged,
                        Raiders = allRaiders.Where(r => r.IsAlt == false && r.Role == WowSpecRole.Ranged).ToList()
                    }
                },
                Alts = new RoleRaidersViewModel
                {
                    Title = "Alts",
                    Tanks = new SingleRoleViewModel
                    {
                        WowSpecRole = WowSpecRole.Tank,
                        Raiders = allRaiders.Where(r => r.IsAlt == true && r.Role == WowSpecRole.Tank).ToList()
                    },
                    Healers = new SingleRoleViewModel
                    {
                        WowSpecRole = WowSpecRole.Healer,
                        Raiders = allRaiders.Where(r => r.IsAlt == true && r.Role == WowSpecRole.Healer).ToList()
                    },
                    Melee = new SingleRoleViewModel
                    {
                        WowSpecRole = WowSpecRole.Melee,
                        Raiders = allRaiders.Where(r => r.IsAlt == true && r.Role == WowSpecRole.Melee).ToList()
                    },
                    Ranged = new SingleRoleViewModel
                    {
                        WowSpecRole = WowSpecRole.Ranged,
                        Raiders = allRaiders.Where(r => r.IsAlt == true && r.Role == WowSpecRole.Ranged).ToList()
                    }
                },
            };

            return rosterCharacters;
        }
    }
}
