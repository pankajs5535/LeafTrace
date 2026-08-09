using AutoMapper;
using LeafTrace.Application.DTOs.WarehouseBinDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class WarehouseBinService : IWarehouseBinService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WarehouseBinService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WarehouseBinDto>> GetAllAsync()
        {
            var data = await _unitOfWork.WarehouseBins.GetAllAsync();
            return _mapper.Map<IEnumerable<WarehouseBinDto>>(data);
        }

        public async Task<WarehouseBinDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.WarehouseBins.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<WarehouseBinDto>(data);
        }

        public async Task<WarehouseBinDto?> GetByCodeAsync(string binCode)
        {
            var data = await _unitOfWork.WarehouseBins.GetByCodeAsync(binCode);
            return data == null ? null : _mapper.Map<WarehouseBinDto>(data);
        }

        public async Task<IEnumerable<WarehouseBinDto>> GetByTypeAsync(string binType)
        {
            var data = await _unitOfWork.WarehouseBins.GetByTypeAsync(binType);
            return _mapper.Map<IEnumerable<WarehouseBinDto>>(data);
        }

        public async Task<IEnumerable<WarehouseBinDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.WarehouseBins.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<WarehouseBinDto>>(data);
        }

        public async Task<IEnumerable<WarehouseBinDto>> GetActiveAsync()
        {
            var data = await _unitOfWork.WarehouseBins.GetActiveAsync();
            return _mapper.Map<IEnumerable<WarehouseBinDto>>(data);
        }

        public async Task<IEnumerable<WarehouseBinDto>> GetInactiveAsync()
        {
            var data = await _unitOfWork.WarehouseBins.GetInactiveAsync();
            return _mapper.Map<IEnumerable<WarehouseBinDto>>(data);
        }

        public async Task<IEnumerable<WarehouseBinDto>> GetByStatusAsync(string status)
        {
            var data = await _unitOfWork.WarehouseBins.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<WarehouseBinDto>>(data);
        }

        public async Task<IEnumerable<WarehouseBinDto>> GetAvailableBinsAsync()
        {
            var data = await _unitOfWork.WarehouseBins.GetAvailableBinsAsync();
            return _mapper.Map<IEnumerable<WarehouseBinDto>>(data);
        }

        public async Task<IEnumerable<WarehouseBinDto>> GetByWarehouseAsync(string warehouseName)
        {
            var data = await _unitOfWork.WarehouseBins.GetByWarehouseAsync(warehouseName);
            return _mapper.Map<IEnumerable<WarehouseBinDto>>(data);
        }

        public async Task<bool> IsBinCodeExistsAsync(string binCode)
        {
            return await _unitOfWork.WarehouseBins.IsBinCodeExistsAsync(binCode);
        }

        public async Task CreateAsync(CreateWarehouseBinDto dto)
        {
            var entity = _mapper.Map<WarehouseBin>(dto);
            await _unitOfWork.WarehouseBins.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateWarehouseBinDto dto)
        {
            var entity = await _unitOfWork.WarehouseBins.GetByIdAsync(dto.BinId);

            if (entity == null)
                throw new Exception("Warehouse Bin not found.");

            _mapper.Map(dto, entity);

            _unitOfWork.WarehouseBins.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.WarehouseBins.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Warehouse Bin not found.");

            _unitOfWork.WarehouseBins.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}