using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MooretrUniversity.Models
{
    public class Student
    {
        // First name parameters
        public int StudentID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name must be less than 50 characters.")] // warning, Whitespace will satisfy these requirements
        [RegularExpression(@"^[A-zÀ-ž]*[- ]?[A-zÀ-ž]*$")] // Match any letters, optionally followed by a single dash or space, followed by any letters
        //[Column("FirstName")] This would change the database column name
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        // Last name parameters
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name must be less than 50 characters.")] // warning, Whitespace will satisfy these requirements
        [RegularExpression(@"^[A-zÀ-ž]*[- ]?[A-zÀ-ž]*$", ErrorMessage = "Enter letters, a dash, or a space.)")] // Match any letters, optionally followed by a single dash or space, followed by any letters
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        // Enrollment date parameters
        [DataType(DataType.Date)] // Only use the date from DateTime
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        // Full name string
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        // Navigation property to the enrollment entity
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
