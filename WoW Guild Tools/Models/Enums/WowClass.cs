using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WoW_Guild_Tools.Models.Enums
{
    public enum WowClass
    {
        [Display(Name = "Select Class")]
        Unset,
        [Display(Name = "Death Knight")]
        DeathKnight,
        Druid,
        Hunter,
        Mage,
        Paladin,
        Priest,
        Rogue,
        Shaman,
        Warlock,
        Warrior
    }
}
