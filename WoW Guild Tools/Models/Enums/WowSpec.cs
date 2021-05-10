using System.ComponentModel.DataAnnotations;

namespace WoW_Guild_Tools.Models
{
    public enum WowSpec
    {
        Balance,
        [Display(Name = "Feral Combat")]
        FeralCombat,
        Restoration,
        [Display(Name = "Beast Mastery")]
        BeastMastery,
        Marksmanship,
        Survival,
        Arcane,
        Fire,
        Frost,
        Holy,
        Protection,
        Retribution,
        Discipline,
        Shadow,
        Assassination,
        Combat,
        Subtlety,
        Elemental,
        Enhancement,
        Affliction,
        Demonology,
        Destruction,
        Arms,
        Fury
    }
}
