using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WoW_Guild_Tools.Models.Enums
{
    public enum WowProfession
    {
        [Display(Name = "Select Profession")]
        Unset,
        Unknown,
        Alchemy,
        Blacksmithing,
        Enchanting,
        Engineering,
        Herbalism,
        Jewelcrafting,
        Leatherworking,
        Mining,
        Skinning,
        Tailoring
    }
}
