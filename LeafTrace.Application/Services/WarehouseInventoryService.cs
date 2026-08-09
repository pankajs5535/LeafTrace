using AutoMapper;
using LeafTrace.Application.DTOs.WarehouseInventoryDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class WarehouseInventoryService : IWarehouseInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WarehouseInventoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WarehouseInventoryDto>> GetAllAsync()
        {
            var data = await _unitOfWork.WarehouseInventories.GetAllAsync();
            return _mapper.Map<IEnumerable<WarehouseInventoryDto>>(data);
        }

        public async Task<WarehouseInventoryDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.WarehouseInventories.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<WarehouseInventoryDto>(data);
        }

        public async Task<IEnumerable<WarehouseInventoryDto>> GetByProductAsync(int productId)
        {
            var data = await _unitOfWork.WarehouseInventories.GetByProductAsync(productId);
            return _mapper.Map<IEnumerable<WarehouseInventoryDto>>(data);
        }

        public async Task<IEnumerable<WarehouseInventoryDto>> GetByRawMaterialAsync(int rawMaterialId)
        {
            var data = await _unitOfWork.WarehouseInventories.GetByRawMaterialAsync(rawMaterialId);
            return _mapper.Map<IEnumerable<WarehouseInventoryDto>>(data);
        }

        public async Task<IEnumerable<WarehouseInventoryDto>> GetByWarehouseBinAsync(int binId)
        {
            var data = await _unitOfWork.WarehouseInventories.GetByBinAsync(binId);
            return _mapper.Map<IEnumerable<WarehouseInventoryDto>>(data);
        }

        public async Task<IEnumerable<WarehouseInventoryDto>> GetExpiredAsync()
        {
            var data = await _unitOfWork.WarehouseInventories.GetExpiredInventoryAsync();
            return _mapper.Map<IEnumerable<WarehouseInventoryDto>>(data);
        }

        public async Task<IEnumerable<WarehouseInventoryDto>> GetLowStockAsync()
        {
            var data = await _unitOfWork.WarehouseInventories.GetLowStockAsync();
            return _mapper.Map<IEnumerable<WarehouseInventoryDto>>(data);
        }

        public async Task<IEnumerable<WarehouseInventoryDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.WarehouseInventories.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<WarehouseInventoryDto>>(data);
        }

        public async Task CreateAsync(CreateWarehouseInventoryDto dto)
        {
            var entity = _mapper.Map<WarehouseInventory>(dto);
            await _unitOfWork.WarehouseInventories.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateWarehouseInventoryDto dto)
        {
            var entity = await _unitOfWork.WarehouseInventories
                .GetByIdAsync(dto.InventoryId);

            if (entity == null)
                throw new Exception("Inventory not found.");

            _mapper.Map(dto, entity);

            _unitOfWork.WarehouseInventories.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.WarehouseInventories.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Inventory not found.");

            _unitOfWork.WarehouseInventories.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}