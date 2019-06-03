using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SommerExam.Data;
using SommerExam.Models;

namespace SommerExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<List<Location>> GetLocations(string name)
        {
            var locations = _context.Locations.Where(p => p.Name.Contains(name)).ToList();

            return locations;
        }
    }
}