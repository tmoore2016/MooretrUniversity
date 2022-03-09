#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MooretrUniversity.Data;
using MoortrUniversity.Models;

namespace MooretrUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly MooretrUniversity.Data.StudentContext _context;

        public IndexModel(MooretrUniversity.Data.StudentContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}
