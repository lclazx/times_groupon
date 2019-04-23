using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq;
using System.Collections.Generic;
namespace TimesGroupon.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Phone")]
        public string Phone { get; set; }

        // [BsonElement]
        // public List<ActivityModel> AttentedActivities { get; set; }
    }
}