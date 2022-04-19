using MooretrUniversity.Data;
using MooretrUniversity.Models;
using MooretrUniversity.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace MooretrUniversity.Pages.Instructors
{
    // Base class for Instructor Edit and Create page models
    public class InstructorCoursesPageModel : PageModel
    {
        public List<AssignedCourseData> AssignedCourseDataList;

        // For each instructor and for each course, set the CourseID, title, and whether or not the instructor is assigned
        public void PopulateAssignedCourseData(SchoolContext context, Instructor instructor)
        {
            var allCourses = context.Courses;

            // Hash the instructor's courses for efficient lookups
            var instructorCourses = new HashSet<int>(instructor.Courses.Select(c => c.CourseID));
            
            AssignedCourseDataList = new List<AssignedCourseData>();

            foreach (var course in allCourses)
            {
                AssignedCourseDataList.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
        }
    }
}
