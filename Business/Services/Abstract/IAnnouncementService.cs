using Entities;
using Entities.Dtos.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IAnnouncementService
    {
        Task<List<AnnouncementGetDto>> GetAll();
        Task<AnnouncementGetDto> GetById(int id);
        Task<AnnouncementGetDto> GetByTitle(string title);
        Task AddAsync(AnnouncementCreateDto announcementCreate);
        Task UpdateAsync(AnnouncementUpdateDto announcementUpdate);
        Task DeleteAsync(int id);
    }
}
