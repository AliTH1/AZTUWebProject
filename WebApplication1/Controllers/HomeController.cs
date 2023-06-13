using Business.Services.Abstract;
using Entities;
using Entities.Dtos.Announcement;
using Entities.Dtos.Panel;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{

    private readonly IPanelService _panelService;

    public HomeController(IPanelService panelService)
    {
        _panelService = panelService;
    }

    public async Task<IActionResult> Index()
    {
        List<PanelGetDto> panelGetDtos = await _panelService.GetAllAsync();

        HomeVM homeVM = new HomeVM()
        {
            Panels = panelGetDtos
        };

        return View(homeVM);
    }
}