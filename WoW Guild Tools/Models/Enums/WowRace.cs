using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WoW_Guild_Tools.Models.Enums
{
    public enum WowRace
    {
        Human,
        Dwarf,
        [Display(Name = "Night Elf")]
        NightElf,
        Gnome,
        Draenei,
        Orc,
        Undead,
        Tauren,
        Troll,
        [Display(Name = "Blood Elf")]
        BloodElf
    }
}
