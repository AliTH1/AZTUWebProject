using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Entities;
using Entities.Dtos.Panel;

namespace Business.Services.Concrete
{
    public class PanelService : IPanelService
    {
        private readonly IPanelRepository _panelRepository;

        private readonly IMapper _mapper;

        public PanelService(IPanelRepository panelRepository, IMapper mapper)
        {
            _panelRepository = panelRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(PanelCreateDto panelCreate)
        {
            if (await _panelRepository.IsExistsAsync(p => p.Title == panelCreate.Title))
            {
                throw new AlreadyIsExistsException(ExceptionMessages.PanelAlreadyExists);
            }

            await _panelRepository.AddAsync(_mapper.Map<Panel>(panelCreate));

            int result = await _panelRepository.SaveAsync();

            if (result == 0)
            {
                throw new Exception("Panel does not added");
            }
        }

        public async Task DeleteAsync(int id)
        {
            Panel panel = await _panelRepository.GetAsync(p => p.Id == id);

            CheckAvailability(panel);

            await _panelRepository.DeleteAsync(panel);
        }

        public async Task<List<PanelGetDto>> GetAllAsync()
        {
            List<Panel> panels = await _panelRepository.GetAllAsync();
            if (panels.Count == 0)
            {
                throw new NotFoundException(ExceptionMessages.PanelNotFound);
            }

            return _mapper.Map<List<PanelGetDto>>(panels);
        }

        public async Task<PanelGetDto> GetById(int id)
        {
            Panel panel = await _panelRepository.GetAsync(p => p.Id == id);

            CheckAvailability(panel);


            return _mapper.Map<PanelGetDto>(panel);
        }

        public async Task<PanelGetDto> GetByTitle(string title)
        {
            Panel panel = await _panelRepository.GetAsync(n => n.Title == title);

            CheckAvailability(panel);

            return _mapper.Map<PanelGetDto>(panel);
        }


        public async Task UpdateAsync(PanelUpdateDto panelUpdate)
        {
            Panel panel = await _panelRepository
                .GetAsync(c => c.Id == panelUpdate.Id);

            CheckAvailability(panel);

            panel.Title = panelUpdate.Title;

            await _panelRepository.UpdateAsync(panel);
        }


        private static void CheckAvailability(Panel panel)
        {
            if (panel == null)
            {
                throw new NotFoundException(ExceptionMessages.PanelNotFound);
            }
        }
    }
}
