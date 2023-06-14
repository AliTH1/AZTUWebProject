using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities;
using Entities.Dtos.Projects;

namespace Business.Services.Concrete;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(ProjectCreateDto projectCreate)
    {
        if (await _projectRepository.IsExistsAsync(p => p.Title == projectCreate.Title))
        {
            throw new AlreadyIsExistsException(ExceptionMessages.ProjectAlreadyExists);
        }

        await _projectRepository.AddAsync(_mapper.Map<Project>(projectCreate));

        int result = await _projectRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Project does not added");
        }
    }

    public async Task DeleteAsync(int id)
    {
        Project project = await _projectRepository.GetAsync(p => p.Id == id);

        CheckAvailability(project);

        await _projectRepository.DeleteAsync(project);
    }

    public async Task<List<ProjectGetDto>> GetAllAsync()
    {
        List<Project> project = await _projectRepository.GetAllAsync();
        if (project.Count == 0)
        {
            throw new NotFoundException(ExceptionMessages.ProjectNotFound);
        }

        return _mapper.Map<List<ProjectGetDto>>(project);
    }

    public async Task<ProjectGetDto> GetById(int id)
    {
        Project Project = await _projectRepository.GetAsync(p => p.Id == id);

        CheckAvailability(Project);


        return _mapper.Map<ProjectGetDto>(Project);
    }

    public async Task<ProjectGetDto> GetByTitle(string title)
    {
        Project project = await _projectRepository.GetAsync(n => n.Title == title);

        CheckAvailability(project);

        return _mapper.Map<ProjectGetDto>(project);
    }


    public async Task UpdateAsync(ProjectUpdateDto projectUpdate)
    {
        Project project = await _projectRepository
            .GetAsync(c => c.Id == projectUpdate.Id);

        CheckAvailability(project);

        project.Title = projectUpdate.Title;
        project.Description = projectUpdate.Description;
        project.Url = projectUpdate.Url;
        project.ImagePath = projectUpdate.ImagePath;
        await _projectRepository.UpdateAsync(project);
    }


    private static void CheckAvailability(Project project)
    {
        if (project == null)
        {
            throw new NotFoundException(ExceptionMessages.ProjectNotFound);
        }
    }
}
