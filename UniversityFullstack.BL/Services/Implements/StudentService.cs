using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityFullstack.BL.Models;
using UniversityFullstack.BL.Repositories;

namespace UniversityFullstack.BL.Services.Implements
{
    public class StudentService : GenericService<Student>
    {
        public StudentService(IStudentRepository studentRepository) : base(studentRepository)
        {

        }
    }
}
