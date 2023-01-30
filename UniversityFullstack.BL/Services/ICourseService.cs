using System.Threading.Tasks;
using UniversityFullstack.BL.Models;

namespace UniversityFullstack.BL.Services
{
    public interface ICourseService : IGenericService<Course>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
