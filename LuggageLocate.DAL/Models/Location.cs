using LuggageLocate.DAL.Models.Enums;

namespace LuggageLocate.DAL.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Luggage Luggage { get; set; }
        public LocationStatus Status { get; set; }


        private Location(Guid usedId, double latitude, double longitude, Luggage luggage) 
        {
            Id = Guid.NewGuid();
            UserId = usedId;
            Latitude = latitude;
            Longitude = longitude;
            Luggage = luggage;
            Status = LocationStatus.Created;
        }

        public static Location Create(Guid usedId, double latitude, double longitude, Luggage luggage)
        {   
            return new Location(usedId, latitude, longitude, luggage);
        }
    }
}
