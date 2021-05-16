using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoW_Guild_Tools.Models.Enums;

namespace WoW_Guild_Tools.Models.ViewModels
{
    public class SingleRole
    {
        public WowSpecRole WowSpecRole { get; set; }
        public List<Raider> Raiders { get; set; }
    }
}
