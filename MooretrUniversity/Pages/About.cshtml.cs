using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MooretrUniversity.Models.SchoolViewModels;
using MooretrUniversity.Data;
using MooretrUniversity.Models;

namespace MooretrUniversity.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SchoolContext _context;

        // Constructor
        public AboutModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> Students { get; set; }


        public async Task OnGetAsync()
        {
            // LINQ statement groups student entities by enrollment date, counts the number of entities in each group, and stores the results in a collection of EnrollmentDateGroup view model objects
            IQueryable<EnrollmentDateGroup> data =
                from student in _context.Students
                group student by student.EnrollmentDate.Date into dateGroup // Only pulls the date, not time from DateTime type.
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };

            Students = await data.AsNoTracking().ToListAsync();
        }
    }
}
