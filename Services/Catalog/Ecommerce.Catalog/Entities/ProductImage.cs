using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text;

namespace Ecommerce.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageID { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public string ProductID { get; set; }  // hata olabilir 
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
