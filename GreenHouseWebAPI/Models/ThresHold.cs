using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouseWebAPI.Models
{
    public class ThresHold
    {

        [Key]
        public int ThresholdId { get; set; } = RandomIDGenerator.Generate(8);
        public float CO2min { get; set; }
        public float CO2max { get; set; }
        public float TempMin { get; set; }
        public float TempMax { get; set; }
        public float HumidityMin { get; set; }
        public float HumidityMax { get; set; }
        public float LightMin { get; set; }
        public float LightMax { get; set; }
       
        public ThresHold() { }

        public ThresHold(float CO2min, float CO2max, float TempMin, float TempMax, float HumidityMin, float HumidityMax, float LightMin, float LightMax)
        {
            this.ThresholdId = RandomIDGenerator.Generate(8);
            this.CO2min = CO2min;
            this.CO2max = CO2max;
            this.TempMin = TempMin;
            this.TempMax = TempMax;
            this.HumidityMin = HumidityMin;
            this.HumidityMax = HumidityMax;
            this.LightMin = LightMin;
            this.LightMax = LightMax;

        }

    }
}
