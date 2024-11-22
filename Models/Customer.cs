namespace CarRepairWorkshop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Navigation property
        public ICollection<Car>? Cars { get; set; }
    }
}
