using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Reflection.Metadata.Ecma335;

namespace Ecommerce.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]   // bu iki attribute MongoDB'de tanımladığımız proportie'nin ID değeri olduğunu belirtir.
        public string CategoryID { get; set; } // MongoDB bir ilişkisel veritabanı olmadığı için ID değeri integer değil string türde tutulur.
                                               // buna bir guide değer atanır
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }


    }
}
