using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis;

namespace SommerExam.Models
{
    public class Sensor
    {
        [BindNever]
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please inter a whole number")]
        public int LocationId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string TreeSpecies { get; set; }

        [Required]
        [MaxLength(16)]
        public string SensorId { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }
    }
}
