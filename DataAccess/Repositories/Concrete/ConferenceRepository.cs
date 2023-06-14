using Core.DataAccess.Repositories.Concrete.EFCore;
using DataAccess.Repositories.Abstract;
using Entities;

namespace DataAccess.Repositories.Concrete
{
    public class ConferenceRepository : EFBaseRepository<Conference, AppDbContext>,
        IConferenceRepository
    {
        public ConferenceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
