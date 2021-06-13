using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WoW_Guild_Tools.Models.Enums;

namespace WoW_Guild_Tools.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public WowProfession ProfessionName { get; set; }

        [Required]
        // Spell / Item - used to specify which type of wowhead tooltip to display
        // (i.e. create the correct link for tooltip)
        public WowType Type { get; set; }

        [Required]
        public int WowRecipeId { get; set; }

        [Required]
        public int WowCraftedItemId { get; set; }

        public List<Raider> CrafterRaiders { get; set; }
    }
}
