using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WoW_Guild_Tools.Models.Enums;

namespace WoW_Guild_Tools.Models
{
    public class Raider
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(12)]
        public string Name { get; set; }

        [Required]
        public WowRace Race { get; set; }

        [Required]
        public WowClass Class { get; set; }

        [Required]
        public WowSpec Spec { get; set; }

        [Required]
        public WowSpecRole Role { get; set; }

        [Required]
        public WowRaiderRank Rank { get; set; }
        // TODO: Validate that profession is unique (can't have 2 of the same)
        public WowProfession Profession1 { get; set; }
        public WowProfession Profession2 { get; set; }

        public int? MainId { get; set; }

        [ForeignKey(nameof(MainId))]
        public Raider Main { get; set; }

        [NotMapped]
        public bool IsAlt => MainId.HasValue;
    }
}
