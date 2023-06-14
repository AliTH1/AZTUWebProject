using Entities.Dtos.Panel;
using Entities.Dtos.Projects;

namespace Business.Services.Abstract
{
    public interface IProjectService
    {
        Task<List<ProjectGetDto>> GetAllAsync();
        Task<ProjectGetDto> GetById(int id);
        Task<ProjectGetDto> GetByTitle(string title);
        Task AddAsync(ProjectCreateDto projectCreate);
        Task UpdateAsync(ProjectUpdateDto projectUpdate);
        Task DeleteAsync(int id);
    }
}
