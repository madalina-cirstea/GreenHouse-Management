using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GreenHouse_Management.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "Sensor name cannot be more than 25!")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Sensor model cannot be more than 20!")]
        public string Model { get; set; }

        [Required]
        public float Value { get; set; }

        [Required]
        public string OperatingState { get; set; }

        public virtual ICollection<SensorUsage> SensorUsages { get; set; }
    }
}