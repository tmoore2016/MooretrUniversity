using System;
using System.ComponentModel.DataAnnotations;

namespace MooretrUniversity.Models.SchoolViewModels
{
    public class CourseEnrollmentGroup
    {
        public int? CourseID { get; set; }
        public string Title { get; set; }
        public int EnrollmentCount { get; set; }
    }
}
