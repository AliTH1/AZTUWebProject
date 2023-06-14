using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities;
using Entities.Dtos.News;

namespace Business.Services.Concrete;

public class NewsService : INewsService
{
    private readonly INewsRepository _newsRepository;
    private readonly IMapper _mapper;

    public NewsService(INewsRepository newsRepository, IMapper mapper)
    {
        _newsRepository = newsRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(NewsCreateDto newsCreate)
    {
        if (await _newsRepository.IsExistsAsync(p => p.Title == newsCreate.Title))
        {
            throw new AlreadyIsExistsException(ExceptionMessages.NewsAlreadyExists);
        }
        
        await _newsRepository.AddAsync(_mapper.Map<News>(newsCreate));

        int result = await _newsRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("News does not added");
        }
    }

    public async Task DeleteAsync(int id)
    {
        News news = await _newsRepository.GetAsync(p => p.Id == id);

        CheckAvailability(news);

        await _newsRepository.DeleteAsync(news);
    }

    public async Task<List<NewsGetDto>> GetAllAsync()
    {
        List<News> news = await _newsRepository.GetAllAsync();
        if (news.Count == 0)
        {
            throw new NotFoundException(ExceptionMessages.NewsNotFound);
        }

        return _mapper.Map<List<NewsGetDto>>(news);
    }

    public async Task<NewsGetDto> GetById(int id)
    {
        News news = await _newsRepository.GetAsync(p => p.Id == id);

        CheckAvailability(news);


        return _mapper.Map<NewsGetDto>(news);
    }

    public async Task<NewsGetDto> GetByTitle(string title)
    {
        News news = await _newsRepository.GetAsync(n => n.Title == title);

        CheckAvailability(news);

        return _mapper.Map<NewsGetDto>(news);
    }


    public async Task UpdateAsync(NewsUpdateDto newsUpdate)
    {
        News news = await _newsRepository
            .GetAsync(c => c.Id == newsUpdate.Id);

        CheckAvailability(news);

        news.Title = newsUpdate.Title;
        news.Date = newsUpdate.Date;
        news.Url = newsUpdate.Url;
        news.Description = newsUpdate.Description;

        await _newsRepository.UpdateAsync(news);
    }


    private static void CheckAvailability(News news)
    {
        if (news == null)
        {
            throw new NotFoundException(ExceptionMessages.NewsNotFound);
        }
    }
}
