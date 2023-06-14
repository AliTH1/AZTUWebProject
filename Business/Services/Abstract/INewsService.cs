
using Entities.Dtos.News;

namespace Business.Services.Abstract
{
    public interface INewsService
    {
        Task<List<NewsGetDto>> GetAllAsync();
        Task<NewsGetDto> GetById(int id);
        Task<NewsGetDto> GetByTitle(string title);
        Task AddAsync(NewsCreateDto newsCreate);
        Task UpdateAsync(NewsUpdateDto newsUpdate);
        Task DeleteAsync(int id);
    }
}
