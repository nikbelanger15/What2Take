using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using What2Take.Model;

namespace What2Take.Services
{
    public class CoursesService {
        private readonly IMongoCollection<Courses> _courses;
        public CoursesService(CoursesDatabaseSettings settings) 
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _courses = database.GetCollection<Courses>(settings.CoursesCollectionName);

            // var collection = client.GetDatabase(settings.DatabaseName).GetCollection<Courses>(settings.CoursesCollectionName);
            // var distinctItems = collection.Distinct<>.ToList();

        }

        // Get Courses to Display on CourseList
        public List<Courses> Get() {
            return _courses.Find(course => true).ToList();
        }   

        // public List<string> GetUniqueCourse() {
        //     var c1 = _courses.Find(course => true);
        //     var uniqueNames = c1.Distinct("Code");
        //     return uniqueNames.ToList();
        // } 

        //Create Course by Submit Page
        public Courses Create(Courses courses) {
            _courses.InsertOne(courses);
            return courses;
        }
    }
}