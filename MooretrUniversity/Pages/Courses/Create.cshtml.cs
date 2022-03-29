using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MooretrUniversity.Data;
using MooretrUniversity.Models;

// This class controls the Create page for Courses
namespace MooretrUniversity.Pages.Courses
{
    //public class CreateModel : PageModel
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly MooretrUniversity.Data.SchoolContext _context;

        public CreateModel(MooretrUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            */
            var emptyCourse = new Course();

            // Prevent overposting with TryUpdateModelAsync
            if (await TryUpdateModelAsync<Course>(
                emptyCourse,
                "course",
                s => s.CourseID, s => s.DepartmentID, s => s.Title, s => s.Credits))
            {
                _context.Courses.Add(emptyCourse);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails
            PopulateDepartmentDropDownList(_context, emptyCourse.DepartmentID);
            return Page();
        }
    }
}
