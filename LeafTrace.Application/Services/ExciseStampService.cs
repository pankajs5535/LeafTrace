using AutoMapper;
using LeafTrace.Application.DTOs.ExciseStampDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class ExciseStampService : IExciseStampService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExciseStampService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExciseStampDto>> GetAllAsync()
        {
            var data = await _unitOfWork.ExciseStamps.GetAllAsync();
            return _mapper.Map<IEnumerable<ExciseStampDto>>(data);
        }

        public async Task<ExciseStampDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.ExciseStamps.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<ExciseStampDto>(data);
        }

        public async Task<ExciseStampDto?> GetBySerialNumberAsync(string serialNumber)
        {
            var data = await _unitOfWork.ExciseStamps.GetBySerialNumberAsync(serialNumber);
            return data == null ? null : _mapper.Map<ExciseStampDto>(data);
        }

        public async Task<IEnumerable<ExciseStampDto>> GetByProductAsync(int productId)
        {
            var data = await _unitOfWork.ExciseStamps.GetByProductAsync(productId);
            return _mapper.Map<IEnumerable<ExciseStampDto>>(data);
        }

        public async Task<IEnumerable<ExciseStampDto>> GetByProductionOrderAsync(int productionOrderId)
        {
            var data = await _unitOfWork.ExciseStamps.GetByProductionOrderAsync(productionOrderId);
            return _mapper.Map<IEnumerable<ExciseStampDto>>(data);
        }

        public async Task<IEnumerable<ExciseStampDto>> GetByStorageBinAsync(int binId)
        {
            var data = await _unitOfWork.ExciseStamps.GetByStorageBinAsync(binId);
            return _mapper.Map<IEnumerable<ExciseStampDto>>(data);
        }

        public async Task<IEnumerable<ExciseStampDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.ExciseStamps.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<ExciseStampDto>>(data);
        }

        public async Task<IEnumerable<ExciseStampDto>> GetByStatusAsync(string status)
        {
            var data = await _unitOfWork.ExciseStamps.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<ExciseStampDto>>(data);
        }

        public async Task<IEnumerable<ExciseStampDto>> GetAvailableAsync()
        {
            var data = await _unitOfWork.ExciseStamps.GetAvailableAsync();
            return _mapper.Map<IEnumerable<ExciseStampDto>>(data);
        }

        public async Task<IEnumerable<ExciseStampDto>> GetAppliedAsync()
        {
            var data = await _unitOfWork.ExciseStamps.GetAppliedAsync();
            return _mapper.Map<IEnumerable<ExciseStampDto>>(data);
        }

        public async Task<bool> IsSerialNumberExistsAsync(string serialNumber)
        {
            return await _unitOfWork.ExciseStamps.IsSerialNumberExistsAsync(serialNumber);
        }

        public async Task CreateAsync(CreateExciseStampDto dto)
        {
            var entity = _mapper.Map<ExciseStamp>(dto);
            await _unitOfWork.ExciseStamps.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateExciseStampDto dto)
        {
            var entity = await _unitOfWork.ExciseStamps.GetByIdAsync(dto.StampId);

            if (entity == null)
                throw new Exception("Excise stamp not found.");

            _mapper.Map(dto, entity);

            _unitOfWork.ExciseStamps.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.ExciseStamps.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Excise stamp not found.");

            _unitOfWork.ExciseStamps.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}