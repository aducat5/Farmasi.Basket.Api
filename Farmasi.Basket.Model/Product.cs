namespace Farmasi.Basket.Model
{
    public record Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public bool IsStocked { get; set; }
        public bool IsDeleted { get; set; }
    }
}