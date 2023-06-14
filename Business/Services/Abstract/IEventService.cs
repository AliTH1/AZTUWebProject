using Entities.Dtos.Events;

namespace Business.Services.Abstract
{
    public interface IEventService
    {
        Task<List<EventGetDto>> GetAllAsync();
        Task<EventGetDto> GetById(int id);
        Task<EventGetDto> GetByTitle(string title);
        Task AddAsync(EventCreateDto eventCreate);
        Task UpdateAsync(EventUpdateDto eventUpdate);
        Task DeleteAsync(int id);
    }
}
