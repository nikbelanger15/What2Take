using MongoDB.Bson.Serialization.Attributes;

namespace What2Take.Model {
    public class Courses {
        [BsonId][BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id {get; set;}
        [BsonElement("code")]
        public string code {get; set;}
        public int difficulty {get; set;}
    }
}