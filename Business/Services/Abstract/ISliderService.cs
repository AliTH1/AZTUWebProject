using Entities.Dtos.Slider;

namespace Business.Services.Abstract
{
    public interface ISliderService
    {
        Task<List<SliderGetDto>> GetAllAsync();
        Task<SliderGetDto> GetById(int id);
        Task AddAsync(SliderCreateDto sliderCreate);
        Task UpdateAsync(SliderUpdateDto sliderUpdate);
        Task DeleteAsync(int id);
    }
}
