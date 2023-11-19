using LuggageLocate.DAL.Models;
using LuggageLocate.DAL.Models.Requests;
using System.ComponentModel.DataAnnotations;

namespace LuggageLocate.BLL.Factory
{
    public static class InstanceFactory
    {
        public static Location CreateLocationFromRequest(LocationCreationRequest request)
        {
            return ResponseMapping.MapToLocationFromRequest(request);
        }

        public static List<Location> CreateMockLocations(int count)
        {   
            Random random = new(Guid.NewGuid().GetHashCode());
            var locations = new List<Location>();

            var ownerIds = new List<Guid>() { Guid.Parse("7411c3a0-7856-4284-b897-6477cf11d6e0") };

            for (int i = 0; i < count; i++)
            {
                var ownerGuid = Guid.NewGuid();
                if (i == 0)
                {
                    ownerGuid = ownerIds[0];
                }
                var destination = Destination.CreateDestination(
                    random.NextDouble(),
                    random.NextDouble(),
                    "city");

                var luggage = Luggage.Create(
                    ownerGuid,
                    random.NextDouble(),
                    "randomDesc",
                    destination);

                locations.Add(Location.Create(ownerGuid,
                    random.NextDouble(),
                    random.NextDouble(),
                    luggage));
            }

            return locations;
        }
    }
}
