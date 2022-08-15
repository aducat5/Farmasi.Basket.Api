using MongoDB.Bson.Serialization.Attributes;

namespace Farmasi.Basket.Model
{
    public record Product
    {
        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [BsonElement("name")]
        public string Name { get; set; } = "";
        
        [BsonElement("price")]
        public decimal Price { get; set; }
        
        [BsonElement("isStocked")]
        public bool IsStocked { get; set; }
        
        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}