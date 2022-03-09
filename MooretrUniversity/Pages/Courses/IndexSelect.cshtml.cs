/* The Courses/IndexSelect pages override the Courses/Index pages and use
 * select statements against the database rather than the "Include" method.
 * Select statements might have better performance in situations where only
 * a single query is necessary. Eager loading is better in situations where
 * a lot of queries would be made.
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MooretrUniversity.Models.SchoolViewModels;

namespace MooretrUniversity.Pages.Courses
{
    public class IndexSelectModel : PageModel
    {
        private readonly MooretrUniversity.Data.SchoolContext _context;

        public IndexSelectModel(MooretrUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        // Use select statement to make explicit calls
        #region snippet_RevisedIndexMethod
        public IList<CourseViewModel> CourseVM { get; set; }

        public async Task OnGetAsync()
        {
            CourseVM = await _context.Courses
                .Select(p => new CourseViewModel
                {
                    CourseID = p.CourseID,
                    Title = p.Title,
                    Credits = p.Credits,
                    DepartmentName = p.Department.Name
                }).ToListAsync();
        }
        #endregion
    }
}