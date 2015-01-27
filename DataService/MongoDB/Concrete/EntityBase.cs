using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataService.MongoDB.Concrete
{
    public abstract class EntityBase
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
