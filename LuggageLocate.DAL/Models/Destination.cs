namespace LuggageLocate.DAL.Models
{
    public class Destination
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
        private Destination(double latitude, double longitude, string city)
        {
            Id = Guid.NewGuid();
            Latitude = latitude;
            Longitude = longitude;
            City = city;
        }

        public static Destination CreateDestination(double latitude, double longitude, string city)
        {
            return new Destination(latitude, longitude, city);
        }
    }
}
