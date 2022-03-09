#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MooretrUniversity.Data;
using MooretrUniversity.Models;

namespace MooretrUniversity.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly MooretrUniversity.Data.SchoolContext _context;

        public DetailsModel(MooretrUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Read the student data from the database
            Student = await _context.Students
                .Include(s => s.Enrollments) // Load the Enrollments navigation property
                .ThenInclude(e => e.Course) // Then load the course navigation property inside enrollments
                .AsNoTracking() // Improves performance for read-only scenarios              
                                // Find the first row that satisfies the query filter criteria, or return null
                .FirstOrDefaultAsync(m => m.StudentID == id); // Find a student ID

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
