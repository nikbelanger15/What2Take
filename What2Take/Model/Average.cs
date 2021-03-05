using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace What2Take.Model {
    public class Average {

        public Average (List<Courses> courses) {
            this.grade = 0; //initialize parameter
            this.difficulty = 0;
            this.departments = new List<string>();
            for (var i=0; i< courses.Count; i++) {
                this.code = courses[i].code;
                this.grade += courses[i].grade;
                this.difficulty += courses[i].difficulty;
                this.departments.Add(courses[i].department);
            }
            this.grade /= courses.Count;
            this.difficulty /= courses.Count;
            this.departments = this.departments.Select(x => x).Distinct().ToList();
        }
        public string code {get; set;}
        public int grade {get;set;}
        public int difficulty {get;set;}

        public List<string> departments { get; set; }
    }
    
}