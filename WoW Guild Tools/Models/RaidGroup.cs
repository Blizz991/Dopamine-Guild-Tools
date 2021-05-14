using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WoW_Guild_Tools.Models
{
    public class RaidGroup
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public bool Published { get; set; }

        [Required, Column(TypeName = "datetime2")]
        public DateTime RaidDay { get; set; }

        [Required, Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }
    }
}
