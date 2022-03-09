#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MooretrUniversity.Data;
using MooretrUniversity.Models;

namespace MooretrUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly MooretrUniversity.Data.SchoolContext _context;

        // Map key-value pairs for paging index
        private readonly IConfiguration Configuration;

        public IndexModel(SchoolContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        // variables to sort the column names in the Razor page, also see Index.cshtml
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        // A collection of all students in the database
        //public IList<Student> Students { get;set; }

        // A paginated list of students from the database
        public PaginatedList<Student> Students { get; set; }

        // Method for sorting by name or date, or to filter by name, using the paginated list
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            // Provide Razor page with the current sort order
            CurrentSort = sortOrder;

            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                // Reset index to filter everything during a search
                pageIndex = 1;
            }
            else
            {
                // Maintain filter settings during paging
                searchString = currentFilter;
            }

            // Provide Razor page with the current filter value
            CurrentFilter = searchString;

            IQueryable<Student> studentsSort = from s in _context.Students select s;

            // Check if the search box contains anything, filter input by first or last name
            if (!String.IsNullOrEmpty(searchString))
            {
                studentsSort = studentsSort.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentsSort = studentsSort.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentsSort = studentsSort.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    studentsSort = studentsSort.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    studentsSort = studentsSort.OrderBy(s => s.LastName);
                    break;
            }

            // PageSize is configured in appsettings.json
            var pageSize = Configuration.GetValue("PageSize", 5);

            // Display the first 10 students without pagination
            //Student = await _context.Students.Take(10).ToListAsync();

            // Use the paginated list to sort and display students by the page index
            Students = await PaginatedList<Student>.CreateAsync(studentsSort.AsNoTracking(), pageIndex ?? 1, pageSize); // Return the value of pageIndex if its not null, otherwise return 1
        }
    }
}
