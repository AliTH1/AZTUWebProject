using Core.DataAccess.Repositories.Concrete.EFCore;
using DataAccess.Repositories.Abstract;
using Entities;

namespace DataAccess.Repositories.Concrete
{
    public class ProjectRepository : EFBaseRepository<Project, AppDbContext>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}
