using LuggageLocate.DAL.Models;
using LuggageLocate.DAL.Models.Requests;

namespace LuggageLocate.BLL
{
    public static class ResponseMapping
    {
        public static Location MapToLocationFromRequest(LocationCreationRequest creationRequest)
        {
            var luggageInfo = Luggage.Create(
                creationRequest.UserId,
                creationRequest.Weight,
                creationRequest.Description,
                creationRequest.Destination);

            return Location.Create(creationRequest.UserId, creationRequest.Latitude, creationRequest.Longitude, luggageInfo);
        }
    }
}
