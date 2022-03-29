using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MooretrUniversity.Data;
using MooretrUniversity.Models;
using MooretrUniversity.Models.SchoolViewModels;

namespace MooretrUniversity.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly MooretrUniversity.Data.SchoolContext _context;

        public IndexModel(MooretrUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        //public IList<Instructor> Instructor { get;set; }

        public InstructorIndexData InstructorData { get; set; }

        public int MyInstructorID { get; set; }

        public int CourseID { get; set; }

        public async Task OnGetAsync(int? instructorid, int? courseid)
        {
            // Query: Eager load Instructor.Office, Instructor.Courses, Course.Department
            InstructorData = new InstructorIndexData();
            InstructorData.Instructors = await _context.Instructors
                .Include(i => i.Office)
                .Include(i => i.Courses)
                    .ThenInclude(c => c.Department)
                .OrderBy(i => i.LastName)
                .ToListAsync();

            // When an instructor is selected, the where method returns a collection, the single method is used on a collection with only 1 entity. The instructor entity provides access to the course navigation property
            if (instructorid != null)
            {
                MyInstructorID = instructorid.Value;
                Instructor instructor = InstructorData.Instructors
                    .Where(i => i.InstructorID == instructorid.Value).Single();
                InstructorData.Courses = instructor.Courses;
            }

            // When a course is selected, the view model's Enrollments property is populated
            if (courseid != null)
            {
                CourseID = courseid.Value;
                var selectedCourse = InstructorData.Courses
                    .Where(x => x.CourseID == courseid).Single();
                await _context.Entry(selectedCourse)
                    .Collection(x => x.Enrollments).LoadAsync();
                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
                }

                InstructorData.Enrollments = selectedCourse.Enrollments;
            }
        }
    }
}
