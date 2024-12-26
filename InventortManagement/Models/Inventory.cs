using MongoDB.Bson.Serialization.Attributes;

namespace InventortManagement.Models
{
    public class Inventory
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public int Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}