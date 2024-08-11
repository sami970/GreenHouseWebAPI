using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouseWebAPI.Models
{
    public class GreenHouse
    {
        [Key]
        public int greenHouseId { get; set; } = RandomIDGenerator.Generate(8);
        public string location { get; set; }
       
        [ForeignKey("ThresholdId")]
        public int ThresholdId { get; set; }
        [ForeignKey("User")]
        public int userId { get; set; }

        public GreenHouse() { }

        public GreenHouse( string Location)
        {
            this.greenHouseId = RandomIDGenerator.Generate(8);
            this.location = location;
            
        }
    }
}
