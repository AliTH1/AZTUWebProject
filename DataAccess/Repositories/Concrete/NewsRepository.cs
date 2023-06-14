using Core.DataAccess.Repositories.Concrete.EFCore;
using DataAccess.Repositories.Abstract;
using Entities;

namespace DataAccess.Repositories.Concrete
{
    public class NewsRepository : EFBaseRepository<News, AppDbContext>,
    INewsRepository
    {
        public NewsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
