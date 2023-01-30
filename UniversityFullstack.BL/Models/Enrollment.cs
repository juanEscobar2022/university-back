using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityFullstack.BL.Models
{
    public enum Grade
    {
        A, B,C, D, E

    }
    [Table("Enrollment", Schema = "dbo")]

    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        //-----se hacen las referencias de las foraneas que hay dentro de la tabla-------

        [ForeignKey("Course")]
        public int CourseID { get; set; }

        [ForeignKey("Student")]

        public int StudentID { get; set; }
        public Grade Grade { get; set; }

        //----------------se establecen las relaciones que hay entre tablas--------------------
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
