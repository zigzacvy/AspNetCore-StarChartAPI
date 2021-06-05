using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var celestialObject = _context.CelestialObjects.FirstOrDefault(x => x.Id == id);
            if (celestialObject == null)
            {
                return NotFound();
            }

            return Ok(celestialObject);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var celestialObject = _context.CelestialObjects.FirstOrDefault(x => x.Name == name);
            if (celestialObject == null)
            {
                return NotFound();
            }

            return Ok(celestialObject);
        }
        
        [HttpGet]
        public IActionResult GetAll(string name)
        {
            return Ok(_context.CelestialObjects);
        }
    }
}
