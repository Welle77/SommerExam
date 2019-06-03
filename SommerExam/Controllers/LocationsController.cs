using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SommerExam.Data;
using SommerExam.Models;
using SommerExam.ViewModels;

namespace SommerExam.Controllers
{
    public class LocationsController : Controller
    {
        private const int LocationsPerPage = 5;

        private readonly ApplicationDbContext _context;

        public LocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Locations
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Locations.ToListAsync());
        //}

        //https://www.c-sharpcorner.com/UploadFile/219d4d/implement-search-paging-and-sort-in-mvc-5/

        public ActionResult Index(string option, string search)
        {
            if (option == "Id")
            {
                return View(_context.Locations.Where(x => search != null && (x.LocationId == int.Parse(search) || search == null))
                    .ToList());
            }
            return View(_context.Locations.Where(x => x.Name.StartsWith(search) || search == null).ToList());
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }

            var tempSensors = _context.Sensors.Where(p => p.LocationId == location.LocationId).ToList();


            var viewModel = new DetailViewModel
            {
                Location = location,
                Sensors = tempSensors
            };


            return View(viewModel);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,Name,Address,AddressNumber,PostalCode,City")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        public async Task<IActionResult> AddSensor(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(p => p.LocationId == id);
            if (location == null)
                return NotFound();

            return View(new Sensor(){LocationId = location.LocationId});
        }
        [HttpPost]
        public async Task<IActionResult> AddSensor(Sensor sensor)
        {
            if (ModelState.IsValid) { 
            var location = await _context.Locations.FirstOrDefaultAsync(p => p.LocationId == sensor.LocationId);
            if (location != null)
                _context.Sensors.Add(sensor);
            await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sensor);
        }


        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}
