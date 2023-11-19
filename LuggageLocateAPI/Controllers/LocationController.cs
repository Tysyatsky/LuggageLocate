using Azure.Core;
using LuggageLocate.BLL;
using LuggageLocate.BLL.Factory;
using LuggageLocate.DAL;
using LuggageLocate.DAL.Models.Enums;
using LuggageLocate.DAL.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design.Serialization;

namespace LuggageLocateAPI.Controllers
{
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly FakeStorage _storage;

        public LocationController(ILogger<LocationController> logger, FakeStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        [HttpGet]
        [Route("/[controller]/get/{ownerIdentifier}")]
        public async Task<IActionResult> GetByOwner([FromRoute] Guid ownerIdentifier)
        {
            try
            {
                var result = _storage.GetLocationByOwnerId(ownerIdentifier);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/[controller]/create")]
        public async Task<IActionResult> Create([FromBody] LocationCreationRequest request)
        {
            try
            {   
                var location = ResponseMapping.MapToLocationFromRequest(request);
                var result = _storage.CreateLocation(location);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/[controller]/edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] LocationStatus locationStatus)
        {
            try
            {
                var result = _storage.EditLocation(id, latitude, longitude, locationStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/[controller]/delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var result = _storage.DeleteLocation(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
