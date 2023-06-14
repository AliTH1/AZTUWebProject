using AutoMapper;
using Entities;
using Entities.Dtos.Events;

namespace Business.Utilities.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventCreateDto, Event>();
            CreateMap<EventUpdateDto, Event>();
            CreateMap<EventGetDto, Event>().ReverseMap();
        }
    }
}
