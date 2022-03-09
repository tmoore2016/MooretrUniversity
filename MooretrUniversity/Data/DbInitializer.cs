using MooretrUniversity.Models;

namespace MooretrUniversity.Data
{
    // DbInitializer seeds the database on creation
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            // Look for instructors
            if (context.Instructors.Any())
            {
                return; // DB already seeded
            }


            var students = new Student[]
            {
                new Student
                {
                    FirstName="Travis", LastName="Moore", EnrollmentDate=DateTime.Parse("2018-09-01")
                },

                new Student
                {
                    FirstName="Jeff", LastName="Black", EnrollmentDate=DateTime.Parse("2017-01-01")
                },

                new Student
                {
                    FirstName="Sarah", LastName="Washington", EnrollmentDate=DateTime.Parse("2018-09-02")
                },

                new Student
                {
                    FirstName="Billy", LastName="Ambrosia", EnrollmentDate=DateTime.Parse("2016-09-01")
                },

                new Student
                {
                    FirstName="Ahmed", LastName="Douglas", EnrollmentDate=DateTime.Parse("2019-01-01")
                },

                new Student
                {
                    FirstName="Francis", LastName="DeLorean", EnrollmentDate=DateTime.Parse("2019-09-03")
                },

                new Student
                {
                    FirstName="Taylor", LastName="Chin", EnrollmentDate=DateTime.Parse("2019-08-25")
                },

                new Student
                {
                    FirstName="Sylvestor", LastName="Gunn", EnrollmentDate=DateTime.Parse("2019-09-01")
                },

                new Student
                {
                    FirstName="Tracy", LastName="Matthews", EnrollmentDate=DateTime.Parse("2018-09-03")
                }
            };

            // Add these students to the data context
            context.AddRange(students);
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor
                {
                    FirstName = "Steve",
                    LastName = "Cox",
                    HireDate = DateTime.Parse("2014-09-01")
                },

                new Instructor
                {
                    FirstName = "Sadia",
                    LastName = "Ahmed",
                    HireDate = DateTime.Parse("2011-03-03")
                },

                new Instructor
                {
                    FirstName = "Brian",
                    LastName = "Malone",
                    HireDate = DateTime.Parse("2009-10-01")
                },

                new Instructor
                {
                    FirstName = "Patty",
                    LastName = "Palomino",
                    HireDate = DateTime.Parse("2000-01-01")
                },

                new Instructor
                {
                    FirstName = "Judy",
                    LastName = "Johnson",
                    HireDate = DateTime.Parse("1990-04-01")
                },
            };

            // Add these students to the data context
            context.AddRange(instructors);
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment
                {
                    InstructorID = 2,
                    Location = "HiTech 202"
                },

                new OfficeAssignment
                {
                    InstructorID = 1,
                    Location = "HiTech 203"
                },

                new OfficeAssignment
                {
                    InstructorID = 3,
                    Location = "HiTech 204"
                },

                new OfficeAssignment
                {
                    InstructorID = 4,
                    Location = "Engr 101"
                },

                new OfficeAssignment
                {
                    InstructorID = 5,
                    Location = "Math 306"
                },

            };
            // Add the office assignments to the context
            context.AddRange(officeAssignments);
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department
                {
                    Name = "Mathematics",
                    Budget = 10000,
                    StartDate = DateTime.Parse("1990-09-01"),
                    Administrator = instructors[4]
                },

                new Department
                {
                    Name = "Engineering",
                    Budget = 50000,
                    StartDate = DateTime.Parse("2002-03-01"),
                    Administrator = instructors[0]
                },

                new Department
                {
                    Name = "Computer Science",
                    Budget = 25000,
                    StartDate = DateTime.Parse("2001-09-01"),
                    Administrator = instructors[1]
                },
            };

            context.AddRange(departments);
            context.SaveChanges();


            var courses = new Course[]
            {
                new Course
                {
                    CourseID=3351, Title="Advanced Programming", Credits=3, DepartmentID=3, Instructors = new List<Instructor>{ instructors[1], instructors[2] }
                },

                new Course
                {
                    CourseID=4480, Title="Engineer and Project Management", Credits=4, DepartmentID=2, Instructors = new List<Instructor>{ instructors[0] }
                },

                new Course
                {
                    CourseID=3350, Title="Database Management", Credits=3, DepartmentID=3, Instructors = new List<Instructor>{ instructors[2] }
                },

                new Course
                {
                    CourseID=4472, Title="Engineering Entrepreneurship", Credits=3, DepartmentID=2, Instructors = new List<Instructor>{ instructors[3] }
                },

                new Course
                {
                    CourseID=4440, Title="Advanced Computer Networks", Credits=3, DepartmentID=3, Instructors = new List<Instructor>{ instructors[2] }
                },

                new Course
                {
                    CourseID=163, Title="Calculus II for Engineers", Credits=4, DepartmentID=1, Instructors = new List<Instructor>{ instructors[0], instructors[4] }
                },

                new Course
                {
                    CourseID=3355, Title="Web Engineering", Credits=3, DepartmentID=2, Instructors = new List<Instructor> { instructors[1], instructors[2] }
                },

            };

            context.AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment
                {
                    StudentID=1,CourseID=3351,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=1,CourseID=4480,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=1,CourseID=3350,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=1,CourseID=4472,Grade=Grade.B
                },

                new Enrollment
                {
                    StudentID=1,CourseID=4440,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=1,CourseID=163,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=1,CourseID=3355,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=2,CourseID=3355,Grade=Grade.B
                },

                new Enrollment
                {
                    StudentID=2,CourseID=4480,Grade=Grade.C
                },

                new Enrollment
                {
                    StudentID=2,CourseID=3351,Grade=Grade.F
                },

                new Enrollment
                {
                    StudentID=3,CourseID=3355,Grade=Grade.B
                },

                new Enrollment
                {
                    StudentID=3,CourseID=4440,Grade=Grade.B
                },

                new Enrollment
                {
                    StudentID=4,CourseID=3351,Grade=Grade.F
                },

                new Enrollment
                {
                    StudentID=4,CourseID=4480,Grade=Grade.F
                },

                new Enrollment
                {
                    StudentID=4,CourseID=3350,Grade=Grade.F
                },

                new Enrollment
                {
                    StudentID=5,CourseID=3355,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=5,CourseID=4440,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=5,CourseID=3351,Grade=Grade.B
                },

                new Enrollment
                {
                    StudentID=5,CourseID=4480,Grade=Grade.B
                },

                new Enrollment
                {
                    StudentID=5,CourseID=3350,Grade=Grade.B
                },

                new Enrollment
                {
                    StudentID=6,CourseID=163,Grade=Grade.C
                },

                new Enrollment
                {
                    StudentID=6,CourseID=3351,Grade=Grade.D
                },

                new Enrollment
                {
                    StudentID=6,CourseID=4480,Grade=Grade.C
                },

                new Enrollment
                {
                    StudentID=6,CourseID=3350,Grade=Grade.C
                },

                new Enrollment
                {
                    StudentID=7,CourseID=3351,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=7,CourseID=4480,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=7,CourseID=3350,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=7,CourseID=4472,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=7,CourseID=4440,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=7,CourseID=163,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=7,CourseID=3355,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=8,CourseID=3351,Grade=Grade.C
                },

                new Enrollment
                {
                    StudentID=8,CourseID=4480,Grade=Grade.C
                },

                new Enrollment
                {
                    StudentID=8,CourseID=3350,Grade=Grade.C
                },

                new Enrollment
                {
                    StudentID=8,CourseID=4472,Grade=Grade.C
                },

                new Enrollment
                {
                    StudentID=8,CourseID=4440,Grade=Grade.C
                },

                new Enrollment
                {
                    StudentID=8,CourseID=163,Grade=Grade.C
                },

                new Enrollment
                {
                    StudentID=8,CourseID=3355,Grade=Grade.C
                },

                new Enrollment
                {
                    StudentID=9,CourseID=4480,Grade=Grade.B
                },

                new Enrollment
                {
                    StudentID=9,CourseID=3350,Grade=Grade.B
                },

                new Enrollment
                {
                    StudentID=9,CourseID=4472,Grade=Grade.A
                },

                new Enrollment
                {
                    StudentID=9,CourseID=4440,Grade=Grade.B
                },

                new Enrollment
                {
                    StudentID=9,CourseID=163,Grade=Grade.B
                },

                new Enrollment
                {
                    StudentID=9,CourseID=3355,Grade=Grade.C
                },

            };

            context.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
