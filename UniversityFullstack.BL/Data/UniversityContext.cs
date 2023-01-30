using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityFullstack.BL.Models;

namespace UniversityFullstack.BL.Data
{
    public class UniversityContext : DbContext
    {
        private static UniversityContext universityContext = null;
        //-----consxion a la base de datos y referencia de tablas de esa BD
        public UniversityContext() : base("UniversityContext")
        {

        }
        public DbSet<Course> Courses { get; set; }  
        public DbSet<Student> Students { get; set; }  
        public DbSet<Enrollment> Enrollments { get; set; }

        public static UniversityContext Create()
        {
            //if (universityContext == null)
            //    universityContext = new UniversityContext();

            return new  UniversityContext();
        }
    }
}
