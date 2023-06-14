using AutoMapper;
using Entities;
using Entities.Dtos.Projects;

namespace Business.Utilities.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<ProjectUpdateDto, Project>();
            CreateMap<ProjectGetDto, Project>().ReverseMap();
        }
    }
}
