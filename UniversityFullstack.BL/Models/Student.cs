using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityFullstack.BL.Models
{
    [Table("Student", Schema = "dbo")]

    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string EnrollmentDate { get; set; }

        public virtual ICollection<Student> Enrollment { get; set; }
    }
}
