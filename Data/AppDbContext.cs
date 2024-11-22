using Microsoft.EntityFrameworkCore;
using CarRepairWorkshop.Models;
using System.Collections.Generic;

namespace CarRepairWorkshop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RepairOrder> RepairOrders { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
    }
}
