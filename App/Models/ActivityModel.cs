using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TimesGroupon.Models
{
    public class ActivityModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ActivityName")]
        public string ActivityName { get; set; }

        [BsonElement("ActivityPrice")]
        public double Price { get; set; }

        [BsonElement("User")]
        public User Host { get; set; }
    }
}