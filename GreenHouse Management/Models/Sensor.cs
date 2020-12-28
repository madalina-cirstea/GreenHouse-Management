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
        public string Name { get; set; }

        [Required]
        public string Model { get; set; }

        public float Value { get; set; }

        [Required]
        public string OperatingState { get; set; }
    }
}