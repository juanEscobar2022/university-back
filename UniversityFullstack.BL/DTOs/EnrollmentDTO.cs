using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityFullstack.BL.DTOs
{
    public enum Grade
    {
        A, B, C, D, E

    }
    public class EnrollmentDTO
    {
        public int EnrollmentID { get; set; }
        //-----se hacen las referencias de las foraneas que hay dentro de la tabla-------

        public int CourseID { get; set; }

        public int StudentID { get; set; }
        public Grade Grade { get; set; }

        //----------------se establecen las relaciones que hay entre tablas--------------------
        public CourseDTO Course { get; set; }
        public StudentDTO Student { get; set; }
    }
}
