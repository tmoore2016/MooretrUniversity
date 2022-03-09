﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoortrUniversity.Models;

namespace MooretrUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<MoortrUniversity.Models.Student> Student { get; set; }

        public DbSet<MoortrUniversity.Models.Course> Course { get; set; }

        public DbSet<MoortrUniversity.Models.Instructor> Instructor { get; set; }
    }
}
