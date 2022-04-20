using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MooretrUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")] // Column mapping is used to change from CLR's decimal type to SQL server's money type
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        // Foreign key
        public int? InstructorID { get; set; } // A department may or may not have an administrator

        // For Concurrency check, if any values have changed while editing, a concurrency exception is thrown
        [Timestamp]
        public byte[] ConcurrencyToken { get; set; }

        // Navigation property named Admin but is an Instructor entity
        public Instructor Administrator { get; set; } // The administrator is always an instructor

        public ICollection<Course> Courses { get; set; } // A department may have many courses
    }
}
