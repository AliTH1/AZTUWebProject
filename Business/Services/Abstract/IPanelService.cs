using Entities.Dtos.Announcement;
using Entities.Dtos.Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IPanelService
    {
        Task<List<PanelGetDto>> GetAllAsync();
        Task<PanelGetDto> GetById(int id);
        Task<PanelGetDto> GetByTitle(string title);
        Task AddAsync(PanelCreateDto panelCreate);
        Task UpdateAsync(PanelUpdateDto panelUpdate);
        Task DeleteAsync(int id);
    }
}
