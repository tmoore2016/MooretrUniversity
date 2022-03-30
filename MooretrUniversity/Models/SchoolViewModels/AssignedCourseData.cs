namespace MooretrUniversity.Models.SchoolViewModels
{
    // Class to track courses assigned to an instructor, used for the Instructor page checkboxes
    public class AssignedCourseData
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}
