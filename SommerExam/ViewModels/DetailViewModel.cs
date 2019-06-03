using System.Collections.Generic;
using SommerExam.Models;

namespace SommerExam.ViewModels
{
    public class DetailViewModel
    {
        public Location Location { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}