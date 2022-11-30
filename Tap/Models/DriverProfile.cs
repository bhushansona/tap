namespace Tap.Models
{
    public class DriverProfile
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string VehicleType { get; set; }
        public double BasePrice { get; set; }
        public double BaseDistance { get; set; }
        public bool IsDeleted{get;set;}
    }
}