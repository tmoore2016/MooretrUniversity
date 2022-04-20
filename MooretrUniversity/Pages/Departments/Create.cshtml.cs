using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MooretrUniversity.Data;
using MooretrUniversity.Models;

namespace MooretrUniversity.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly MooretrUniversity.Data.SchoolContext _context;

        public CreateModel(MooretrUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        // Replace ViewData["InstructorID"]
        public SelectList InstructorNameSL { get; set; }

        public IActionResult OnGet()
        {
            // Use strongly typed data rather than ViewData
            //ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "FirstName");
            InstructorNameSL = new SelectList(_context.Instructors, "InstructorID", "FullName");
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
