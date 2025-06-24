using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NanoidDotNet;

namespace HotelBooking.Domain.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; } = string.Empty;

        [BsonElement("PublicId")]
        public string PublicId { get; private set; } = string.Empty;

        protected BaseEntity(){}

        public void GenerateIdsIfNeeded()
        {
            Id ??= ObjectId.GenerateNewId().ToString();
            PublicId = Nanoid.Generate(size: 21);
        }
    }
}
