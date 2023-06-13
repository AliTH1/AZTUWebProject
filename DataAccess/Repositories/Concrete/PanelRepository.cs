using Core.DataAccess.Repositories.Concrete.EFCore;
using DataAccess.Repositories.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class PanelRepository : EFBaseRepository<Panel, AppDbContext>, IPanelRepository
    {
        public PanelRepository(AppDbContext context) : base(context)
        {
        }
    }
}
