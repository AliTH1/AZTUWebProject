using Entities.Dtos.Announcement;
using Entities.Dtos.Conferences;
using Entities.Dtos.Events;
using Entities.Dtos.News;
using Entities.Dtos.Panel;
using Entities.Dtos.Projects;

namespace WebApplication1.ViewModels
{
    public class HomeVM
    {
        public List<PanelGetDto> Panels { get; set; }
        public List<NewsGetDto> News { get; set; }
        public List<AnnouncementGetDto> Announcements { get; set; }
        public List<ProjectGetDto> Projects { get; set; }
        public List<EventGetDto> Events { get; set; }
        public List<ConferenceGetDto> Conferences { get; set; }

    }
}
