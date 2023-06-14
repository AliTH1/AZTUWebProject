using AutoMapper;
using Entities;
using Entities.Dtos.Conferences;
using Entities.Dtos.Projects;

namespace Business.Utilities.Profiles
{
    public class ConferenceProfile : Profile
    {
        public ConferenceProfile()
        {
            CreateMap<ConferenceCreateDto, Conference>();
            CreateMap<ConferenceUpdateDto, Conference>();
            CreateMap<ConferenceGetDto, Conference>().ReverseMap();
        }
    }
}
