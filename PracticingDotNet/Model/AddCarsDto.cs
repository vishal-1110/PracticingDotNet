namespace PracticingDotNet.Model
{
    public class AddCarsDto
    {
        public required string Company { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }
}
