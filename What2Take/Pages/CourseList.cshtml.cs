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

        public IEnumerable<Courses> Courses;
        public CourseListModel(ILogger<CourseListModel> logger, CoursesService CrsService)
        {
            _logger = logger;
            MyCoursesService = CrsService;
        }

        public void OnGet()
        {
            Courses = MyCoursesService.Get();
        }
    }
}
