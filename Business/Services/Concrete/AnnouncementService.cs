using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities;
using Entities.Dtos.Announcement;

namespace Business.Services.Concrete;

public class AnnouncementService : IAnnouncementService
{
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly IMapper _mapper;

    public AnnouncementService(IAnnouncementRepository announcementRepository, IMapper mapper)
    {
        _announcementRepository = announcementRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(AnnouncementCreateDto announcementCreate)
    {
        if(await _announcementRepository.IsExistsAsync(p => p.Title == announcementCreate.Title))
        {
            throw new AlreadyIsExistsException(ExceptionMessages.AnnouncementAlreadyExists);
        }

        await _announcementRepository.AddAsync(_mapper.Map<Announcement>(announcementCreate));

        int result = await _announcementRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Announcement does not added");
        }
    }

    public async Task DeleteAsync(int id)
    {
        Announcement announcement = await _announcementRepository.GetAsync(p => p.Id == id);

        CheckAvailability(announcement);

        await _announcementRepository.DeleteAsync(announcement);
    }

    public async Task<List<AnnouncementGetDto>> GetAll()
    {
        List<Announcement> announcements = await _announcementRepository.GetAllAsync();
        if (announcements.Count == 0)
        {
            throw new NotFoundException(ExceptionMessages.AnnouncementNotFound);
        }

        return _mapper.Map<List<AnnouncementGetDto>>(announcements);
    }

    public async Task<AnnouncementGetDto> GetById(int id)
    {
        Announcement announcement = await _announcementRepository.GetAsync(p => p.Id == id);

        CheckAvailability(announcement);


        return _mapper.Map<AnnouncementGetDto>(announcement);
    }

    public async Task<AnnouncementGetDto> GetByTitle(string title)
    {
        Announcement announcement = await _announcementRepository.GetAsync(n => n.Title == title);

        CheckAvailability(announcement);

        return _mapper.Map<AnnouncementGetDto>(announcement);
    }


    public async Task UpdateAsync(AnnouncementUpdateDto announcementUpdate)
    {
        Announcement announcement = await _announcementRepository
            .GetAsync(c => c.Id == announcementUpdate.Id);

        CheckAvailability(announcement);

        announcement.Title = announcementUpdate.Title;
        announcement.Date = announcementUpdate.Date;

        await _announcementRepository.UpdateAsync(announcement);
    }


    private static void CheckAvailability(Announcement announcement)
    {
        if (announcement == null)
        {
            throw new NotFoundException(ExceptionMessages.AnnouncementNotFound);
        }
    }
}
