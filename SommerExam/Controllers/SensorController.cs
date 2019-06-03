using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SommerExam.Data;
using SommerExam.Models;

namespace SommerExam.Controllers
{
    public class SensorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SensorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddSensor(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(p => p.LocationId == id);
            if (location == null)
                return NotFound();

            return View(new Sensor() { LocationId = location.LocationId });
        }
        [HttpPost]
        public async Task<IActionResult> AddSensor(Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                var location = await _context.Locations.FirstOrDefaultAsync(p => p.LocationId == sensor.LocationId);
                if (location != null)
                    _context.Sensors.Add(sensor);
                await _context.SaveChangesAsync();
                return RedirectToAction("SensorAdded");
            }
            return View(sensor);
        }

        public IActionResult SensorAdded()
        {
            return View();
        } 
    }
}