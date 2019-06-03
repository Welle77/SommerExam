using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SommerExam.Models
{
    public class Location
    {

        [BindNever]
        public int LocationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Number")]
        public string AddressNumber { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string City { get; set; }

        public List<Sensor> Sensors = new List<Sensor>();

    }
}