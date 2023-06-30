using AutoMapper;
using Entities;
using Entities.Dtos.Panel;
using Entities.Dtos.Slider;

namespace Business.Utilities.Profiles
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            CreateMap<Slider, SliderGetDto>().ReverseMap();
            CreateMap<SliderUpdateDto, Slider>();
            CreateMap<SliderGetDto, Slider>().ReverseMap();

        }
    }

}
