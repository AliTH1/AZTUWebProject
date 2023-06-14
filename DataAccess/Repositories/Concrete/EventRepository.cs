using Core.DataAccess.Repositories.Concrete.EFCore;
using DataAccess.Repositories.Abstract;
using Entities;

namespace DataAccess.Repositories.Concrete
{
    public class EventRepository : EFBaseRepository<Event, AppDbContext>,
    IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context)
        {
        }
    }
}
