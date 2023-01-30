using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityFullstack.BL.Data;
using UniversityFullstack.BL.Models;

namespace UniversityFullstack.BL.Repositories.Implements
{
    public class StudentRepository : GenericRepository<Student>
    {
        public StudentRepository(UniversityContext universityContext) : base(universityContext)
        {

        }
    }
}
