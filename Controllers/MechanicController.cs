using Microsoft.AspNetCore.Mvc;
using CarRepairWorkshop.Data;
using CarRepairWorkshop.Models;

namespace CarRepairWorkshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MechanicController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MechanicController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var mechanics = _context.Mechanics.ToList();
            return Ok(mechanics);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var mechanic = _context.Mechanics.Find(id);
            if (mechanic == null) return NotFound();
            return Ok(mechanic);
        }

        [HttpPost]
        public IActionResult Create(Mechanic mechanic)
        {
            _context.Mechanics.Add(mechanic);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = mechanic.Id }, mechanic);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Mechanic updatedMechanic)
        {
            var mechanic = _context.Mechanics.Find(id);
            if (mechanic == null) return NotFound();

            mechanic.Name = updatedMechanic.Name;
            mechanic.Specialization = updatedMechanic.Specialization;
            mechanic.Phone = updatedMechanic.Phone;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mechanic = _context.Mechanics.Find(id);
            if (mechanic == null) return NotFound();

            _context.Mechanics.Remove(mechanic);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
