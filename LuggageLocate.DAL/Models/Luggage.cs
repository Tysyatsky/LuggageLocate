namespace LuggageLocate.DAL.Models
{
    public class Luggage
    {
        public Guid Id { get; set; }

        public Guid OwnerIdentifier { get; set; }

        public double Weight { get; set; }

        public Destination Destination { get; set; }

        public string Description { get; set; }

        private Luggage(Guid owner, double weight, string desc, Destination destination) 
        {
            OwnerIdentifier = owner;
            Weight = weight;
            Destination = destination;
            Description = desc;
        }

        public static Luggage Create(Guid owner, double weight, string desc, Destination destination)
        {
            return new Luggage(owner,
                weight,
                desc,
                destination);
        }
    }
}
