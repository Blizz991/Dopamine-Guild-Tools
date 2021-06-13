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
    public class Raider
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(12)]
        public string Name { get; set; }

        // Using Nchar instead of Nvarchar for performance --- it's faster to look for something we know is smaller.
        [Required, Column(TypeName = "nchar(8)"), EnumValidation]
        public WowRace Race { get; set; }

        [Required, Column(TypeName = "nchar(8)"), EnumValidation]
        public WowClass Class { get; set; }

        [Required, Column(TypeName = "nchar(13)"), EnumValidation]
        public WowSpec Spec { get; set; }

        [Required, Column(TypeName = "nchar(6)"), EnumValidation]
        public WowSpecRole Role { get; set; }

        [Required, Column(TypeName = "nchar(11)"), EnumValidation]
        public WowRaiderRank Rank { get; set; }

        // TODO: Validate that profession is unique (can't have 2 of the same)
        [Required, Column(TypeName = "nchar(15)"), EnumValidation]
        public WowProfession Profession1 { get; set; }

        [Required, Column(TypeName = "nchar(15)"), EnumValidation]
        public WowProfession Profession2 { get; set; }

        public List<Recipe> Recipes { get; set; }

        public int? MainId { get; set; }

        [ForeignKey(nameof(MainId))]
        public Raider Main { get; set; }

        [NotMapped]
        public bool IsAlt => MainId.HasValue;
    }
}
