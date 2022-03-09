using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoortrUniversity.Models
{
    public class Instructor
    {
        public int InstructorID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name must be less than 50 characters.")] // warning, Whitespace will satisfy these requirements
        [RegularExpression(@"^[A-zÀ-ž]*[- ]?[A-zÀ-ž]*$", ErrorMessage = "Enter letters, a dash, or a space.)")] // Match any letters, optionally followed by a single dash or space, followed by any letters
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name must be less than 50 characters.")] // warning, Whitespace will satisfy these requirements
        [RegularExpression(@"^[A-zÀ-ž]*[- ]?[A-zÀ-ž]*$", ErrorMessage = "Enter letters, a dash, or a space.)")] // Match any letters, optionally followed by a single dash or space, followed by any letters
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)] // Only use the date from DateTime
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        // Full name string
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        // Navigation properties
        public ICollection<Course> Courses { get; set; } // An instructor can teach multiple courses, so a collection is used

        public OfficeAssignment Office { get; set; }
    }
}
