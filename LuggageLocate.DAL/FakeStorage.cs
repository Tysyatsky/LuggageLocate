using LuggageLocate.DAL.Factory;
using LuggageLocate.DAL.Models;
using LuggageLocate.DAL.Models.Enums;

namespace LuggageLocate.DAL
{
    public class FakeStorage
    {
        public List<Location> Locations { get; set; }
        public FakeStorage()
        {
            Locations = InstanceFactory.CreateMockLocations(10);
        }

        public Location GetLocationByOwnerId(Guid ownerId)
        {
            return Locations.Find(x => x.UserId == ownerId) 
                ?? throw new ArgumentException("No locations was found by id: {id}", ownerId.ToString());
        }

        public Location CreateLocation(Location location)
        {
            if (Locations.Exists(x => x.Luggage.Destination.Latitude == location.Luggage.Destination.Latitude && 
                x.Luggage.Destination.Longitude == location.Luggage.Destination.Longitude))
            {
                throw new ArgumentException("Location already exists : {id}", location.Id.ToString());
            }

            Locations.Add(location);

            return location;
        }

        public Guid EditLocation(Guid id, double latitude, double longitude, LocationStatus status)
        {
            if (!Locations.Exists(x => x.Id == id))
            {
                throw new ArgumentException("No such location was found!");
            }

            var location = Locations.Single(x => x.Id == id);

            Locations.Remove(location);

            location.Status = status;
            location.Latitude = latitude;
            location.Longitude = longitude;

            Locations.Add(location);

            return location.Id;
        }

        public Guid DeleteLocation(Guid id)
        {
            if (!Locations.Exists(x => x.Id == id))
            {
                throw new ArgumentException("No such location was found!");
            }

            var location = Locations.Single(x => x.Id == id);

            Locations.Remove(location);

            return location.Id;
        }

    }
}
