using MooretrUniversity.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// This class provides a list of department names that are used by the Course Create and Edit pages for their dropdown lists
namespace MooretrUniversity.Pages.Courses
{
    public class DepartmentNamePageModel : PageModel
    {
        public SelectList DepartmentNameSL { get; set; }

        public void PopulateDepartmentDropDownList(SchoolContext _context, object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments orderby d.Name select d;

            DepartmentNameSL = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }
    }
}
