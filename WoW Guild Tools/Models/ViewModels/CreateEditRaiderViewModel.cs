using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WoW_Guild_Tools.Models.ViewModels
{
    public class CreateEditRaiderViewModel
    {
        public bool Alt { get; set; }
        public Raider Raider { get; set; }
        public List<Raider> MainRaiders { get; set; }
    }
}
