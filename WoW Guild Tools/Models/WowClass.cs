//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;
//using WoW_Guild_Tools.Models.Enums;

//namespace WoW_Guild_Tools.Models
//{
//    public class WowClass
//    {
//        [Key]
//        public int WowClassId { get; set; }
//        [Required]
//        public Class Name { get; set; }
//        // MANY classes to MANY races
//        // https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#many-to-many
//        public List<WowRace> WowRaces { get; set; }
//        public List<WowSpec> WowSpecs { get; set; }
//    }
//}
