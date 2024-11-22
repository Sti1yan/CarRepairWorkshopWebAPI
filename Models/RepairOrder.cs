namespace CarRepairWorkshop.Models
{
    public class RepairOrder
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }

        // Foreign keys
        public int CarId { get; set; }
        public int MechanicId { get; set; }

        // Navigation properties
        public Car? Car { get; set; }
        public Mechanic? Mechanic { get; set; }
    }
}
