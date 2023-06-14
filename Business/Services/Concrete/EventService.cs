using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities;
using Entities.Dtos.Events;

namespace Business.Services.Concrete;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public EventService(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(EventCreateDto eventCreate)
    {
        if (await _eventRepository.IsExistsAsync(p => p.Title == eventCreate.Title))
        {
            throw new AlreadyIsExistsException(ExceptionMessages.EventAlreadyExists);
        }

        await _eventRepository.AddAsync(_mapper.Map<Event>(eventCreate));

        int result = await _eventRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Event does not added");
        }
    }

    public async Task DeleteAsync(int id)
    {
        Event dbEvent = await _eventRepository.GetAsync(p => p.Id == id);

        CheckAvailability(dbEvent);

        await _eventRepository.DeleteAsync(dbEvent);
    }

    public async Task<List<EventGetDto>> GetAllAsync()
    {
        List<Event> dbEvent = await _eventRepository.GetAllAsync();
        if (dbEvent.Count == 0)
        {
            throw new NotFoundException(ExceptionMessages.EventNotFound);
        }

        return _mapper.Map<List<EventGetDto>>(dbEvent);
    }

    public async Task<EventGetDto> GetById(int id)
    {
        Event dbEvent = await _eventRepository.GetAsync(p => p.Id == id);

        CheckAvailability(dbEvent);


        return _mapper.Map<EventGetDto>(dbEvent);
    }

    public async Task<EventGetDto> GetByTitle(string title)
    {
        Event dbEvent = await _eventRepository.GetAsync(n => n.Title == title);

        CheckAvailability(dbEvent);

        return _mapper.Map<EventGetDto>(dbEvent);
    }


    public async Task UpdateAsync(EventUpdateDto eventUpdate)
    {
        Event dbEvent = await _eventRepository
            .GetAsync(c => c.Id == eventUpdate.Id);

        CheckAvailability(dbEvent);

        dbEvent.Date = eventUpdate.Date;
        dbEvent.Title = eventUpdate.Title;
        dbEvent.Url = eventUpdate.Url;
        await _eventRepository.UpdateAsync(dbEvent);
    }


    private static void CheckAvailability(Event dbEvent)
    {
        if (dbEvent == null)
        {
            throw new NotFoundException(ExceptionMessages.EventNotFound);
        }
    }
}
