using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NanoidDotNet;

namespace HotelBooking.Domain.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; private set; }

        [BsonElement("PublicId")]
        public string PublicId { get; private set; }

        protected BaseEntity()
        {
            Id = ObjectId.GenerateNewId().ToString();
            PublicId = Nanoid.Generate(size: 21);
        }
    }
}
