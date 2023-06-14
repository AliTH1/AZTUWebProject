using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities;
using Entities.Dtos.Conferences;
using Entities.Dtos.Events;

namespace Business.Services.Concrete;

public class ConferenceService : IConferenceService
{
    private readonly IConferenceRepository _conferenceRepository;
    private readonly IMapper _mapper;

    public ConferenceService(IConferenceRepository conferenceRepository, IMapper mapper)
    {
        _conferenceRepository = conferenceRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(ConferenceCreateDto conferenceCreate)
    {
        if (await _conferenceRepository.IsExistsAsync(p => p.Title == conferenceCreate.Title))
        {
            throw new AlreadyIsExistsException(ExceptionMessages.ConferenceAlreadyExists);
        }

        await _conferenceRepository.AddAsync(_mapper.Map<Conference>(conferenceCreate));

        int result = await _conferenceRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Conference does not added");
        }
    }

    public async Task DeleteAsync(int id)
    {
        Conference conference = await _conferenceRepository.GetAsync(p => p.Id == id);

        CheckAvailability(conference);

        await _conferenceRepository.DeleteAsync(conference);
    }

    public async Task<List<ConferenceGetDto>> GetAllAsync()
    {
        List<Conference> conferences = await _conferenceRepository.GetAllAsync();
        if (conferences.Count == 0)
        {
            throw new NotFoundException(ExceptionMessages.ConferenceNotFound);
        }

        return _mapper.Map<List<ConferenceGetDto>>(conferences);
    }

    public async Task<ConferenceGetDto> GetById(int id)
    {
        Conference conference = await _conferenceRepository.GetAsync(p => p.Id == id);

        CheckAvailability(conference);


        return _mapper.Map<ConferenceGetDto>(conference);
    }

    public async Task<ConferenceGetDto> GetByTitle(string title)
    {
        Conference conference = await _conferenceRepository.GetAsync(n => n.Title == title);

        CheckAvailability(conference);

        return _mapper.Map<ConferenceGetDto>(conference);
    }


    public async Task UpdateAsync(ConferenceUpdateDto conferenceUpdate)
    {
        Conference conference = await _conferenceRepository
            .GetAsync(c => c.Id == conferenceUpdate.Id);

        CheckAvailability(conference);

        conference.Title = conferenceUpdate.Title;
        conference.ImagePath = conferenceUpdate.ImagePath;
        conference.Url = conferenceUpdate.Url;
        await _conferenceRepository.UpdateAsync(conference);
    }


    private static void CheckAvailability(Conference conference)
    {
        if (conference == null)
        {
            throw new NotFoundException(ExceptionMessages.ConferenceNotFound);
        }
    }
}