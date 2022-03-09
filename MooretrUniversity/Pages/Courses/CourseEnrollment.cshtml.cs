using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MooretrUniversity.Data;
using MooretrUniversity.Models;
using MooretrUniversity.Models.SchoolViewModels;

namespace MooretrUniversity.Pages

{
    public class CourseEnrollmentModel : PageModel
    {
        private readonly SchoolContext _context;

        public CourseEnrollmentModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<CourseEnrollmentGroup> Students { get; set; }
        public IList<CourseEnrollmentGroup> Enrollments { get; set; }
        public IList<CourseEnrollmentGroup> Courses { get; set; }

        /*
         *  Not functioning correctly. An issue with pulling data from multiple tables.
         *  
        public async Task OnGetAsync()
        {
            IQueryable<CourseEnrollmentGroup> data =
                from enrollment in _context.Enrollments
                join course in _context.Courses
                on enrollment.EnrollmentID equals (course.CourseID)
                where enrollment.CourseID == course.CourseID
                group enrollment by enrollment.CourseID into enrollmentGroup
                          
                select new CourseEnrollmentGroup()
                {
                    CourseID = enrollmentGroup.Key,
                    Title = "Title placeholder",
                    EnrollmentCount = enrollmentGroup.Count(),
                };
        }

        */
    }
}
