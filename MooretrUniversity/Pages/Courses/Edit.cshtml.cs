using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MooretrUniversity.Data;
using MooretrUniversity.Models;

namespace MooretrUniversity.Pages.Courses
{
    //public class EditModel : PageModel
    public class EditModel : DepartmentNamePageModel
    {
        private readonly MooretrUniversity.Data.SchoolContext _context;

        public EditModel(MooretrUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseID == id);
            Course = await _context.Courses.Include(c => c.Department).FirstOrDefaultAsync(m => m.CourseID == id);

            if (Course == null)
            {
                return NotFound();
            }

            // select current department ID
            PopulateDepartmentDropDownList(_context, Course.DepartmentID);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseToUpdate = await _context.Courses.FindAsync(id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Course>(
                courseToUpdate,
                "course",
                c => c.Credits, c => c.DepartmentID, c => c.Title))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails
            PopulateDepartmentDropDownList(_context, courseToUpdate.DepartmentID);
            return Page();
        }
    }
}
