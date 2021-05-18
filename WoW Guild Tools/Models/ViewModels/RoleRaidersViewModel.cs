using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoW_Guild_Tools.Models.Enums;

namespace WoW_Guild_Tools.Models.ViewModels
{
    public class RoleRaidersViewModel
    {
        public string Title { get; set; }
        public SingleRoleViewModel Tanks { get; set; }
        public SingleRoleViewModel Healers { get; set; }
        public SingleRoleViewModel Melee { get; set; }
        public SingleRoleViewModel Ranged { get; set; }
    }
}
