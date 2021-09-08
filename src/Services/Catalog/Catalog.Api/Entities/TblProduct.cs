using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Entities
{
    public class TblProduct
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        
        [BsonElement("Category")]
        public string Category { get; set; }
        
        [BsonElement("Summary")]
        public string Summary { get; set; }
        
        [BsonElement("Description")]
        public string Description { get; set; }
        
        [BsonElement("ImageFile")]
        public string ImageFile { get; set; }
        
        [BsonElement("Price")]
        public decimal Price { get; set; }


    }
}
