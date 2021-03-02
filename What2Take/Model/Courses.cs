using MongoDB.Bson.Serialization.Attributes;

namespace What2Take.Model {
    public class Courses {

        // set structure of data
        [BsonId][BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id {get; set;}
        public string code {get; set;}
        public int difficulty {get; set;}
        public string grade { get; set; }
    }
}