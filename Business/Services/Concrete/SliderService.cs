using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities;
using Entities.Dtos.Slider;

namespace Business.Services.Concrete
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;

        private readonly IMapper _mapper;

        public SliderService(ISliderRepository sliderRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(SliderCreateDto sliderCreate)
        {
            if (await _sliderRepository.IsExistsAsync(p => p.ImagePath == sliderCreate.ImagePath))
            {
                throw new AlreadyIsExistsException(ExceptionMessages.SliderAlreadyExists);
            }

            await _sliderRepository.AddAsync(_mapper.Map<Slider>(sliderCreate));

            int result = await _sliderRepository.SaveAsync();

            if (result == 0)
            {
                throw new Exception("Slider does not added");
            }
        }

        public async Task DeleteAsync(int id)
        {
            Slider slider = await _sliderRepository.GetAsync(p => p.Id == id);

            CheckAvailability(slider);

            await _sliderRepository.DeleteAsync(slider);
        }

        public async Task<List<SliderGetDto>> GetAllAsync()
        {
            List<Slider> sliders = await _sliderRepository.GetAllAsync();
            if (sliders.Count == 0)
            {
                throw new NotFoundException(ExceptionMessages.SliderNotFound);
            }

            return _mapper.Map<List<SliderGetDto>>(sliders);
        }

        public async Task<SliderGetDto> GetById(int id)
        {
            Slider slider = await _sliderRepository.GetAsync(p => p.Id == id);

            CheckAvailability(slider);


            return _mapper.Map<SliderGetDto>(slider);
        }

        public async Task<SliderGetDto> GetByTitle(string imagePath)
        {
            Slider slider = await _sliderRepository.GetAsync(n => n.ImagePath == imagePath);

            CheckAvailability(slider);

            return _mapper.Map<SliderGetDto>(slider);
        }


        public async Task UpdateAsync(SliderUpdateDto sliderUpdate)
        {
            Slider slider = await _sliderRepository
                .GetAsync(c => c.Id == sliderUpdate.Id);

            CheckAvailability(slider);

            slider.ImagePath = sliderUpdate.ImagePath;

            await _sliderRepository.UpdateAsync(slider);
        }


        private static void CheckAvailability(Slider slider)
        {
            if (slider == null)
            {
                throw new NotFoundException(ExceptionMessages.PanelNotFound);
            }
        }
    }
}
