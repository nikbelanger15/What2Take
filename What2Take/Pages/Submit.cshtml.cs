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
    public class SubmitModel : PageModel
    {
        private readonly ILogger<SubmitModel> _logger;
        public CoursesService MyCoursesService;
        public IEnumerable<Courses> Courses;

        public SubmitModel(ILogger<SubmitModel> logger, CoursesService CrsService)
        {
            _logger = logger;
            MyCoursesService = CrsService;
        }

        public void OnPost()
        {
            var courseCode = Request.Form["courseCode"];
            var difficulty = Request.Form["difficulty"];
            var grade = Request.Form["grade"];
            var department = Request.Form["department"];
            var comments = Request.Form["comments"];

            var data = new Courses(courseCode, Int32.Parse(difficulty), Int32.Parse(grade), department, comments);

            MyCoursesService.Create(data);

        }
    }
}
