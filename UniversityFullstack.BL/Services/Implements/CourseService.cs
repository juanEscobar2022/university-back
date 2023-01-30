using System.Threading.Tasks;
using UniversityFullstack.BL.Models;
using UniversityFullstack.BL.Repositories;

namespace UniversityFullstack.BL.Services.Implements
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        private readonly ICourseRepository courseRepository;
        public CourseService(ICourseRepository courseRepository) : base(courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await courseRepository.DeleteCheckOnEntity(id);
        }
    }
}
