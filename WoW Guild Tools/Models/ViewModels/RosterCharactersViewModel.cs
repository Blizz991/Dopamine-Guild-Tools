using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoW_Guild_Tools.Models.ViewModels
{
    public class RosterCharactersViewModel
    {
        public RoleRaidersViewModel Mains { get; set; }
        public RoleRaidersViewModel Alts { get; set; }
    }
}
