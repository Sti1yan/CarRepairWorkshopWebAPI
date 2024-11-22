namespace CarRepairWorkshop.Models
{
    public class Mechanic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Phone { get; set; }

        // Navigation property
        public ICollection<RepairOrder>? RepairOrders { get; set; }
    }
}
