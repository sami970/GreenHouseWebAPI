using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GreenHouseWebAPI.Models
{
    public class Measurement
    {

        [Key]
        public int MeasurementId { get; set; } = RandomIDGenerator.Generate(8);
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float Light { get; set; }
        public float CO2 { get; set; }
        public DateTime timestamp { get; set; }
       
        [ForeignKey("GreenHouse")]
        public string greenHouseId { get; set; }

        public Measurement() { }

        public Measurement(float temperature, float humidity, float Light, float CO2)
        {
            this.MeasurementId = RandomIDGenerator.Generate(8);
            this.Temperature = temperature;
            this.Humidity = humidity;
            this.Light = Light;
            this.CO2 = CO2;
            this.timestamp = DateTime.UtcNow;
           
        }

    }
}
