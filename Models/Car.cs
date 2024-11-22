namespace CarRepairWorkshop.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }

        // Foreign key
        public int CustomerId { get; set; }

        // Navigation properties
        public Customer? Customer { get; set; }
        public ICollection<RepairOrder>? RepairOrders { get; set; }
    }
}
