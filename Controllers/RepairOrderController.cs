using Microsoft.AspNetCore.Mvc;
using CarRepairWorkshop.Data;
using CarRepairWorkshop.Models;

namespace CarRepairWorkshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepairOrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RepairOrderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _context.RepairOrders.ToList();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _context.RepairOrders.Find(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create(RepairOrder repairOrder)
        {
            _context.RepairOrders.Add(repairOrder);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = repairOrder.Id }, repairOrder);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RepairOrder updatedOrder)
        {
            var order = _context.RepairOrders.Find(id);
            if (order == null) return NotFound();

            order.Description = updatedOrder.Description;
            order.Status = updatedOrder.Status;
            order.Cost = updatedOrder.Cost;
            order.Date = updatedOrder.Date;
            order.CarId = updatedOrder.CarId;
            order.MechanicId = updatedOrder.MechanicId;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _context.RepairOrders.Find(id);
            if (order == null) return NotFound();

            _context.RepairOrders.Remove(order);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
