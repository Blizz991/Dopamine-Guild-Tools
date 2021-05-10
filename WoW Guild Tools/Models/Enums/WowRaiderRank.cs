using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WoW_Guild_Tools.Models.Enums
{
    public enum WowRaiderRank
    {
        [Display(Name = "Guild Master")]
        GuildMaster,
        Officer,
        Raider,
        Trial,
        Member
    }
}
