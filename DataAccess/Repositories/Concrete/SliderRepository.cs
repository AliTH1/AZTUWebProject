using Core.DataAccess.Repositories.Concrete.EFCore;
using DataAccess.Repositories.Abstract;
using Entities;

namespace DataAccess.Repositories.Concrete
{
    public class SliderRepository : EFBaseRepository<Slider, AppDbContext>,
    ISliderRepository
    {
        public SliderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
