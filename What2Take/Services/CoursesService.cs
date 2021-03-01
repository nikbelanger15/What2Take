using MongoDB.Driver;
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
        }

        public List<Courses> Get() {
            return _courses.Find(course => true).ToList();
        }    
    }
         
}