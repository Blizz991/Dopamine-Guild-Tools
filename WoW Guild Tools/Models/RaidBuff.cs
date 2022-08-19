using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WoW_Guild_Tools.Models.Enums;

namespace WoW_Guild_Tools.Models
{
    public class RaidBuff
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SpellId { get; set; }
        public WowClass Class { get; set; }
        public WowSpec Spec { get; set; }
    }
}
