using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MooretrUniversity.Data;
using MooretrUniversity.Models;

namespace MooretrUniversity.Pages.Instructors
{
    public class DeleteModel : PageModel
    {
        private readonly MooretrUniversity.Data.SchoolContext _context;

        public DeleteModel(MooretrUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Instructor = await _context.Instructors.FirstOrDefaultAsync(m => m.InstructorID == id);

            if (Instructor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Instructor instructor = await _context.Instructors
                .Include(i => i.Courses)
                .SingleAsync(i => i.InstructorID == id);

            if (instructor == null)
            {
                return RedirectToPage("./Index");
            }
            
            // Check if the instructor is a deparment administrator
            var departments = await _context.Departments
                .Where(d => d.InstructorID == id)
                .ToListAsync();

            // Check if the instructor is assigned to any departments
            departments.ForEach(d => d.InstructorID = null);

            // Remove the instructor from all positions
            _context.Instructors.Remove(instructor);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
