using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WoW_Guild_Tools.Models
{
    public class GroupRaider
    {
        [Key]
        public int Id { get; set; }

        [Required, Range(1, 8)]
        public int GroupNumber { get; set; }

        [Required, Range(1, 5)]
        public int GroupPosition { get; set; }

        public int RaidGroupId { get; set; }

        [ForeignKey(nameof(RaidGroupId))]
        public RaidGroup Raid { get; set; }

        public int RaiderId { get; set; }

        [ForeignKey(nameof(RaiderId))]
        public Raider Raider { get; set; }
    }
}
