using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WoW_Guild_Tools.Models.Enums
{
    public enum WowFaction
    {
        [Display(Name = "Select Faction")]
        Unset,
        Alliance,
        Horde
    }
}
