using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WoW_Guild_Tools.Models.Enums
{
    public enum WowRaiderRank
    {
        [Display(Name = "Select Rank")]
        Unset,
        [Display(Name = "Guild Master")]
        GuildMaster,
        Officer,
        Raider,
        Trial,
        [Display(Name ="Raider Alt")]
        RaiderAlt,
        Member
    }
}
