/*  This model shows data from a single table, Student.
*/

using System;
using System.ComponentModel.DataAnnotations;

namespace MooretrUniversity.Models.SchoolViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}
