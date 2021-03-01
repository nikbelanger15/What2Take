using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using What2Take.Services;
using What2Take.Model;

namespace What2Take.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public CoursesService MyCoursesService;

        public IEnumerable<Courses> Courses;
        public IndexModel(ILogger<IndexModel> logger, CoursesService CrsService)
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
