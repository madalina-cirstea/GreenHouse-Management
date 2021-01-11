using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenHouse_Management.Models
{
    public class SensorUsage
    {
        public int SensorUsageId { get; set; }

        [Required]
        [Display(Name = "Recorded type")]
        [MaxLength(15, ErrorMessage = "Recorded type cannot be more than 15!")]
        public string RecordedType { get; set; }

        [Required]
        [Display(Name = "Measurement unit")]
        [MaxLength(15, ErrorMessage = "Measurement unit cannot be more than 15!")]
        public string MeasurementUnit { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Description cannot be more than 100!")]
        public string Description { get; set; }

        public virtual ICollection<Sensor> Sensors { get; set; }
    }
}