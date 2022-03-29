using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MooretrUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Allows the app to specify the primary key
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }


        //Foreign key 
        public int DepartmentID { get; set; }

        // Navigation properties
        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } // A course can have multiple enrollments
        public ICollection<Instructor> Instructors { get; set; } // A course can have multiple instructors
    }
}
