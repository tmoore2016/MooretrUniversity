using System.ComponentModel.DataAnnotations;

namespace MooretrUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        // Primary Key
        public int EnrollmentID { get; set; }
        // Foreign keys
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; } // Nullable property
        // Navigation properties
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
