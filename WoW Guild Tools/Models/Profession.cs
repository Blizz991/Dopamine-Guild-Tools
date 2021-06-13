using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WoW_Guild_Tools.Infrastructure;
using WoW_Guild_Tools.Models.Enums;

namespace WoW_Guild_Tools.Models
{
    public class Profession
    {
        [Key, Column(TypeName = "nchar(15)"), EnumValidation]
        public WowProfession Name { get; set; }

        public List<Recipe> Recipes { get; set; }
    }
}
