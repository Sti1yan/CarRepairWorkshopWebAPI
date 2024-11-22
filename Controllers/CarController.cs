using Microsoft.AspNetCore.Mvc;
using CarRepairWorkshop.Data;
using CarRepairWorkshop.Models;

namespace CarRepairWorkshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var cars = _context.Cars.ToList();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var car = _context.Cars.Find(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Car updatedCar)
        {
            var car = _context.Cars.Find(id);
            if (car == null) return NotFound();

            car.Make = updatedCar.Make;
            car.Model = updatedCar.Model;
            car.Year = updatedCar.Year;
            car.LicensePlate = updatedCar.LicensePlate;
            car.CustomerId = updatedCar.CustomerId;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var car = _context.Cars.Find(id);
            if (car == null) return NotFound();

            _context.Cars.Remove(car);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

