using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using What2Take.Model;
using System;

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

        //return unique course codes
        public List<Average> GetUniqueCourse() {
            List<Courses> c1 = _courses.Find(course => true).ToList();
            
            List<string> uniqueNames = new List<string>();
            for (var i = 0; i < c1.Count; i++) {
                bool exists = false;
                for (var j = 0; j < uniqueNames.Count; j++) {
                    if (uniqueNames[j] == c1[i].code) {
                        exists = true;
                        break;
                    }
                }
                if (!exists) {
                    uniqueNames.Add(c1[i].code); 
                }
            }
            List<Average> averages = new List<Average>();
            for (var i=0; i<uniqueNames.Count; i++) {
                List<Courses> tempCourses = c1.Where(o => o.code == uniqueNames[i]).ToList();
                averages.Add(new Average(tempCourses));
                averages = averages.OrderBy(o=>o.code).ToList();
                
            }
            return averages;
        } 
        

        //Create Course by Submit Page
        public Courses Create(Courses courses) {
            _courses.InsertOne(courses);
            return courses;


        }

        public List<Average> GetFiltered(string filter, string sort) {
            List<Average> averages = GetUniqueCourse();
            List<Average> filtered = new List<Average>();
            if (filter != "Select") {
                for (int i=0; i < averages.Count; i++) {
                    if (averages[i].departments.Contains(filter)) {
                        filtered.Add(averages[i]);
                    }
                }
            }
            else {
                filtered = averages;
            }
            if (sort == "grade") {
                filtered = filtered.OrderBy(o=>o.grade).ToList();
            }
            if (sort == "difficulty") {
                filtered = filtered.OrderBy(o=>o.difficulty).ToList();
            }
            if (sort == "code") {
                filtered = filtered.OrderBy(o=>o.code).ToList();
            }
            return filtered;
            }   


        public List<Courses> getCoursesByCode(string code) {
                var c1 = _courses.Find(course => true).ToList();
                List<Courses> tempCourses = c1.Where(o => o.code == code).ToList();
                return tempCourses;
            }
    }
}