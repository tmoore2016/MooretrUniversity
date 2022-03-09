using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MooretrUniversity.Data;
using MooretrUniversity.Models;

namespace MooretrUniversity.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly MooretrUniversity.Data.SchoolContext _context;

        public DetailsModel(MooretrUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses
                .Include(e => e.Enrollments) // Load the Enrollments navigation property
                .ThenInclude(s => s.Student) // Then load the course navigation property inside enrollments
                .AsNoTracking() // Improves performance for read-only scenarios              
                                // Find the first row that satisfies the query filter criteria, or return null
                .FirstOrDefaultAsync(m => m.CourseID == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
