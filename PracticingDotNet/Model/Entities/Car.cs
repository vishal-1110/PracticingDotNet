namespace PracticingDotNet.Model.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public required string Company { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }
}
