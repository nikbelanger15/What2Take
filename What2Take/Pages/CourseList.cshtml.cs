using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using What2Take.Model;
using What2Take.Services;

namespace What2Take.Pages
{
    public class CourseListModel : PageModel
    {
        private readonly ILogger<CourseListModel> _logger;

        public CoursesService MyCoursesService;
        public IEnumerable<Average> averages;
        public IEnumerable<Average> Averages {
            get {
                if (this.averages == null) return Enumerable.Empty<Average>();
                else return this.averages;
            }
            set {this.averages = value;}
        }
        public CourseListModel(ILogger<CourseListModel> logger, CoursesService CrsService)
        {
            _logger = logger;
            this.MyCoursesService = CrsService;
        }



        public void OnGet()
        {

            averages = MyCoursesService.GetUniqueCourse();
        }

        public void OnPost()
        {
            Console.WriteLine(Request.Form["sort"]);
            Console.WriteLine(Request.Form["filter"]);
            averages = MyCoursesService.GetFiltered(Request.Form["filter"], Request.Form["sort"]);
        }
    }
}
