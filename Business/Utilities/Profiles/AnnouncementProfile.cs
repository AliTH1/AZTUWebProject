using AutoMapper;
using Entities;
using Entities.Dtos.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Profiles
{
    public class AnnouncementProfile : Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<AnnouncementCreateDto, Announcement>();
            CreateMap<AnnouncementUpdateDto, Announcement>();
            CreateMap<AnnouncementGetDto, Announcement>().ReverseMap();
        }
    }
}
