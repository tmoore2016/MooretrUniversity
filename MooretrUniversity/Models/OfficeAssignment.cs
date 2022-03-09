using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MooretrUniversity.Models
{
    public class OfficeAssignment
    {
        // Both primary key and foreign key
        [Key] // Explicit because EF Core won't recognize a primary key unless it is thisClassNameID
        public int InstructorID { get; set; } // int type is non-nullable, an office assignment only exists when it has been assigned to an instructor (one to zero relationship)
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }
        public Instructor Instructor { get; set; }
    }
}
