using Core.DataAccess.Repositories.Abstract;
using Entities;
using Entities.Dtos.Announcement;
using Entities.Dtos.Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IPanelRepository : IRepository<Panel>
    {
    }
}
