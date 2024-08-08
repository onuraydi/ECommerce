﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecommerce.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductOldPrice { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageURL { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryID { get; set; }  // burada belki hata çıkabilir ctegory entities'inde aynı ismi kullandık
        [BsonIgnore]   // ?
        public Category Category { get; set; }
    }
}
