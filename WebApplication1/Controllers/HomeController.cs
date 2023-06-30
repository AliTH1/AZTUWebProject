using Business.Services.Abstract;
using Entities;
using Entities.Dtos.Announcement;
using Entities.Dtos.Conferences;
using Entities.Dtos.Events;
using Entities.Dtos.News;
using Entities.Dtos.Panel;
using Entities.Dtos.Projects;
using Entities.Dtos.Slider;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{

    private readonly IPanelService _panelService;
    private readonly INewsService _newsService;
    private readonly IAnnouncementService _announcementService;
    private readonly IProjectService _projectService;
    private readonly IEventService _eventService;
    private readonly IConferenceService _conferenceService;
    private readonly ISliderService _sliderService;

    public HomeController(IPanelService panelService, INewsService newsService, IAnnouncementService announcementService, IProjectService projectService, IEventService eventService, ISliderService sliderService)
    {
        _panelService = panelService;
        _newsService = newsService;
        _announcementService = announcementService;
        _projectService = projectService;
        _eventService = eventService;
        _sliderService = sliderService;
    }

    public async Task<IActionResult> Index()
    {
        List<PanelGetDto> panelGetDtos = await _panelService.GetAllAsync();
        List<NewsGetDto> newsGetDtos = await _newsService.GetAllAsync();
        List<AnnouncementGetDto> announcementGetDtos = await _announcementService.GetAllAsync();
        List<ProjectGetDto> projectGetDtos = await _projectService.GetAllAsync();
        List<EventGetDto> eventGetDtos = await _eventService.GetAllAsync();
        List<SliderGetDto> sliderGetDtos = await _sliderService.GetAllAsync();
        //List<ConferenceGetDto> conferenceGetDtos = await _conferenceService.GetAllAsync();

        HomeVM homeVM = new HomeVM()
        {
            Panels = panelGetDtos,
            News = newsGetDtos,
            Announcements = announcementGetDtos,
            Projects = projectGetDtos,
            Events = eventGetDtos,
            Sliders = sliderGetDtos
            //Conferences = conferenceGetDtos
        };

        return View(homeVM);
    }
}