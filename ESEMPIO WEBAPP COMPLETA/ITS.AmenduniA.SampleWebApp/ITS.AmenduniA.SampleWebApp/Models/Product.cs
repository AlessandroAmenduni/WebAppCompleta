namespace ITS.AmenduniA.SampleWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; } //opzione nullable solo con .net 6
        public decimal Price { get; set; }
    }
}
