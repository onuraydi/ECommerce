using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.Catalog.Entities
{
    public class OfferDiscount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OfferDiscounId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ButtonText { get; set; }
        public string ImageUrl { get; set; }
    }
}
