using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MooretrUniversity.Data;
using MooretrUniversity.Models;

namespace UniversityAPI.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly MooretrUniversity.Data.SchoolContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(MooretrUniversity.Data.SchoolContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string IDSort { get; set; }
        public string TitleSort { get; set; }
        public string CreditsSort { get; set; }
        public string DepartmentSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Course> Courses { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            IDSort = sortOrder == "ID" ? "ID_desc" : "ID";
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            CreditsSort = sortOrder == "credits" ? "credits_desc" : "credits";
            DepartmentSort = String.IsNullOrEmpty(sortOrder) ? "depart_desc" : "department";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            // IQs don't send a query until the object is converted into a collection 
            IQueryable<Course> coursesSort = from c in _context.Courses select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                coursesSort = coursesSort.Where(c => c.Title.Contains(searchString) || c.Department.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "ID":
                    coursesSort = coursesSort.OrderBy(c => c.CourseID);
                    break;
                case "ID_desc":
                    coursesSort = coursesSort.OrderByDescending(c => c.CourseID);
                    break;
                case "title_desc":
                    coursesSort = coursesSort.OrderByDescending(c => c.Title);
                    break;
                case "credits":
                    coursesSort = coursesSort.OrderBy(c => c.Credits);
                    break;
                case "credits_desc":
                    coursesSort = coursesSort.OrderByDescending(c => c.Credits);
                    break;
                case "department":
                    coursesSort = coursesSort.OrderBy(c => c.Department.Name);
                    break;
                case "depart_desc":
                    coursesSort = coursesSort.OrderByDescending(c => c.Department.Name);
                    break;
                default:
                    coursesSort = coursesSort.OrderBy(c => c.Title);
                    break;
            }

            /*
            // Executes the single query from the IQ
            Courses = await coursesSort
                .Include(c => c.Department)
                .AsNoTracking() // Better performance for read-only
                .ToListAsync();
            */
            var pageSize = Configuration.GetValue("PageSize", 5);

            Courses = await PaginatedList<Course>.CreateAsync(coursesSort.Include(c => c.Department).AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
