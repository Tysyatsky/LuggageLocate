namespace LuggageLocate.DAL.Models.Requests
{
    public class LocationCreationRequest
    {
        public Guid UserId { get; set; }
        public Destination Destination { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
