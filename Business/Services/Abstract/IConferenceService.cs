using Entities.Dtos.Conferences;
using Entities.Dtos.Events;

namespace Business.Services.Abstract
{
    public interface IConferenceService
    {
        Task<List<ConferenceGetDto>> GetAllAsync();
        Task<ConferenceGetDto> GetById(int id);
        Task<ConferenceGetDto> GetByTitle(string title);
        Task AddAsync(ConferenceCreateDto conferenceCreate);
        Task UpdateAsync(ConferenceUpdateDto conferenceUpdate);
        Task DeleteAsync(int id);
    }
}
