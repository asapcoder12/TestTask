using AutoMapper;
using TestTask.Business.Interfaces;
using TestTask.Business.DTO;
using TestTask.DataAccess.UnitOfWork.Interfaces;
using TestTask.Entities;
using System.Linq.Expressions;
using TestTask.Utils.Exceptions;

namespace TestTask.Business.Implementations
{
    public class CitizenService : IService<CitizenDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CitizenService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(CitizenDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Citizen entity cannot be null.");
            }

            try
            {
                var citizen = _mapper.Map<Citizen>(entity);
                await _unitOfWork.CitizenRepository.Create(citizen);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Creating citizen error {ex.Message}");
                throw;
            }
        }

        public async Task<CitizenDTO> Get(int id)
        {
            try
            {
                var citizen = await _unitOfWork.CitizenRepository.Get(id);

                if (citizen == null)
                {
                    throw new NotFoundException($"Citizen with ID {id} not found.");
                }

                var citizenDTO = _mapper.Map<CitizenDTO>(citizen);

                return citizenDTO;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Getting citizen error {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<CitizenDTO>> GetAll()
        {
            try
            {
                var citizens = await _unitOfWork.CitizenRepository.GetAll(isTracking: false);
                var mappedCitizens = _mapper.Map<IEnumerable<CitizenDTO>>(citizens);

                return mappedCitizens;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Getting all citizens error {ex.Message}");
                throw;
            }
        }

        public async Task Remove(int id)
        {
            try
            {
                var citizen = await _unitOfWork.CitizenRepository.Get(id);

                if (citizen == null)
                {
                    throw new NotFoundException($"Citizen with ID {id} not found.");
                }

                _unitOfWork.CitizenRepository.Delete(citizen);
                await _unitOfWork.Save();
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deleting citizen error {ex.Message}");
                throw;
            }
        }

        public async Task Update(CitizenDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Citizen entity cannot be null.");
            }

            if ((await _unitOfWork.CitizenRepository.Get(entity.Id)) == null)
            {
                throw new NotFoundException($"Citizen with ID {entity.Id} not found.");
            }

            try
            {
                var citizen = _mapper.Map<Citizen>(entity);

                _unitOfWork.CitizenRepository.Update(citizen);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Updating citizen error {ex.Message}");
                throw;
            }
        }
    }
}
