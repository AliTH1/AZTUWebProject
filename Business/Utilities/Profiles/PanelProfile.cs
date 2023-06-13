using AutoMapper;
using Entities;
using Entities.Dtos.Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Profiles
{
    public class PanelProfile : Profile
    {
        public PanelProfile() 
        {
            CreateMap<Panel, PanelGetDto>().ReverseMap();
            CreateMap<PanelUpdateDto, Panel>();
            CreateMap<PanelGetDto, Panel>().ReverseMap();

        }
    }
}
