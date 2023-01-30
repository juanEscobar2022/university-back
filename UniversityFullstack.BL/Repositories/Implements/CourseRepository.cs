using System.Data.Entity;
using System.Threading.Tasks;
using UniversityFullstack.BL.Data;
using UniversityFullstack.BL.Models;

namespace UniversityFullstack.BL.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly UniversityContext universityContext;
        public CourseRepository(UniversityContext universityContext) : base(universityContext)
        {
            this.universityContext = universityContext;
        }
         
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await universityContext.Enrollments.AnyAsync(x =>x.CourseID == id);
            return flag;
        }
    }
}
