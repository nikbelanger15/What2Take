using MongoDB.Bson.Serialization.Attributes;

namespace What2Take.Model {
    public class Courses {

        public Courses (string code, int difficulty, string grade, string department, string comments) {
            this.code = code;
            this.department = department;
            this.difficulty = difficulty;
            this.grade = grade;
            this.comments = comments;
        }
        
        // set structure of data
        [BsonId][BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id {get; set;}
        public string code {get; set;}
        public string department {get; set;}
        public int difficulty {get; set;}
        public string grade {get; set;}
        public string comments { get; set; }
    }
}