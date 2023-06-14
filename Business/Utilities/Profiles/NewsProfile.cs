using AutoMapper;
using Entities;
using Entities.Dtos.News;

namespace Business.Utilities.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<NewsCreateDto, News>();
            CreateMap<NewsUpdateDto, News>();
            CreateMap<NewsGetDto, News>().ReverseMap();
        }
    }
}
