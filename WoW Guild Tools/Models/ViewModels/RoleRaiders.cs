using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoW_Guild_Tools.Models.Enums;

namespace WoW_Guild_Tools.Models.ViewModels
{
    public class RoleRaiders
    {
        public SingleRole Tanks { get; set; }
        public SingleRole Healers { get; set; }
        public SingleRole Melee { get; set; }
        public SingleRole Ranged { get; set; }
    }
}
