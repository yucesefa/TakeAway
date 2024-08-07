﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TakeAway.Catalog.Entities
{
    public class Product
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string MainDescription { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
