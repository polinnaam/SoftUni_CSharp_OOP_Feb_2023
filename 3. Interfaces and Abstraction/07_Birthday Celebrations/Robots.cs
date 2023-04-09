namespace BirthdayCelebrations
{
    public class Robots : ISpecificSign
    {
        public Robots (string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
