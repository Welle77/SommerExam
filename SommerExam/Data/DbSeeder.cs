using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SommerExam.Models;

namespace SommerExam.Data
{
    public class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Locations.Any())
            {
                context.Locations.AddRange(
                    new Location { Address = "Skovkildeparken", AddressNumber = "2", City = "Skanderborg", PostalCode = "8660", Name = "Engen", Sensors = new List<Sensor>(){new Sensor { TreeSpecies = "Birch", LocationId = 0, Latitude = 12.112, Longitude = 12.112, SensorId = "125AD12456BB4444" } } },
                    new Location { Address = "Havevej", AddressNumber = "12", City = "Aarhus", PostalCode = "8702", Name = "Bakken", Sensors = new List<Sensor>(){ new Sensor { TreeSpecies = "Birch", LocationId = 1, Latitude = 12.112, Longitude = 12.112, SensorId = "125AD12456BB4444" } } },
                    new Location { Address = "Møllevej", AddressNumber = "20", City = "Skanderborg", PostalCode = "8660", Name = "Bækken", Sensors = new List<Sensor>(){ new Sensor { TreeSpecies = "Birch", LocationId = 2, Latitude = 12.112, Longitude = 12.112, SensorId = "125AD12456BB4444" } } },
                    new Location { Address = "Sovevej", AddressNumber = "15", City = "Silkeborg", PostalCode = "8100", Name = "Huset"},
                    new Location { Address = "Sandkassevej", AddressNumber = "29", City = "Virring", PostalCode = "1200", Name = "Møllen"}
                    );
            }
            context.SaveChanges();
        }
    }
}
