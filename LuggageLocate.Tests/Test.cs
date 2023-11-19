using LuggageLocate.DAL;
using LuggageLocate.DAL.Factory;

namespace LuggageLocate.Tests
{
    public class Test
    {
        [Fact]
        public void CreateLocation_ShouldResponseSuccessful()
        {
            var locations = InstanceFactory.CreateMockLocations(2);

            FakeStorage fakeStorage = new();

            var result = fakeStorage.CreateLocation(locations[1]);

            Assert.NotNull(result);
        }

        [Fact]
        public void CreateLocation_ShouldResponseFailed()
        {
            var locations = InstanceFactory.CreateMockLocations(2);

            FakeStorage fakeStorage = new();

            fakeStorage.CreateLocation(locations[0]);

            Assert.Throws<ArgumentException>(() => fakeStorage.CreateLocation(locations[0]));
        }

        [Fact]
        public void UpdateLocationStatus_ShouldResponseSuccessful() 
        {
            var locations = InstanceFactory.CreateMockLocations(1);

            FakeStorage fakeStorage = new();

            fakeStorage.CreateLocation(locations[0]);
            
            var result = fakeStorage.EditLocation(locations[0].Id, 10.0, 10.0, DAL.Models.Enums.LocationStatus.Boarded);

            Assert.Multiple(() =>
            {
                Assert.Equal(result.ToString(), locations[0].Id.ToString());
                Assert.True(locations[0].Status == DAL.Models.Enums.LocationStatus.Boarded);
            });
        }
            
        [Fact]
        public void UpdateLocationStatus_ShouldResponseFailed()
        {
            var locations = InstanceFactory.CreateMockLocations(2);

            FakeStorage fakeStorage = new();

            fakeStorage.CreateLocation(locations[0]);

            Assert.Throws<ArgumentException>(() => fakeStorage.EditLocation(locations[1].Id, 10.0, 10.0, DAL.Models.Enums.LocationStatus.Boarded));
        }

        [Fact]
        public void DeleteLocation_ShouldResponseSuccessful()
        {
            var locations = InstanceFactory.CreateMockLocations(1);

            FakeStorage fakeStorage = new();

            fakeStorage.CreateLocation(locations[0]);

            var result = fakeStorage.DeleteLocation(locations[0].Id);

            Assert.Multiple(() =>
            {
                Assert.Equal(result.ToString(), locations[0].Id.ToString());
                Assert.True(!fakeStorage.Locations.Exists(x => x.Id == result));
            });
        }

        [Fact]
        public void DeleteLocation_ShouldResponseFailed()
        {
            var locations = InstanceFactory.CreateMockLocations(2);

            FakeStorage fakeStorage = new();

            fakeStorage.CreateLocation(locations[0]);

            Assert.Throws<ArgumentException>(() => fakeStorage.DeleteLocation(locations[1].Id));
        }
    }
}
