using AutoMapper;
using LeafTrace.Application.DTOs.RawMaterialDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class RawMaterialService : IRawMaterialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RawMaterialService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RawMaterialDto>> GetAllAsync()
        {
            var data = await _unitOfWork.RawMaterials.GetAllAsync();
            return _mapper.Map<IEnumerable<RawMaterialDto>>(data);
        }

        public async Task<RawMaterialDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.RawMaterials.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<RawMaterialDto>(data);
        }

        public async Task<RawMaterialDto?> GetByCodeAsync(string code)
        {
            var data = await _unitOfWork.RawMaterials.GetByCodeAsync(code);
            return data == null ? null : _mapper.Map<RawMaterialDto>(data);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetByTypeAsync(string type)
        {
            var data = await _unitOfWork.RawMaterials.GetByTypeAsync(type);
            return _mapper.Map<IEnumerable<RawMaterialDto>>(data);
        }

        public async Task<IEnumerable<RawMaterialDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.RawMaterials.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<RawMaterialDto>>(data);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetActiveAsync()
        {
            var data = await _unitOfWork.RawMaterials.GetActiveAsync();
            return _mapper.Map<IEnumerable<RawMaterialDto>>(data);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetInactiveAsync()
        {
            var data = await _unitOfWork.RawMaterials.GetInactiveAsync();
            return _mapper.Map<IEnumerable<RawMaterialDto>>(data);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            var data = await _unitOfWork.RawMaterials.GetByDateRangeAsync(fromDate, toDate);
            return _mapper.Map<IEnumerable<RawMaterialDto>>(data);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetLowStockAsync()
        {
            var data = await _unitOfWork.RawMaterials.GetLowStockAsync();
            return _mapper.Map<IEnumerable<RawMaterialDto>>(data);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetBySupplierAsync(int supplierId)
        {
            var data = await _unitOfWork.RawMaterials.GetBySupplierAsync(supplierId);
            return _mapper.Map<IEnumerable<RawMaterialDto>>(data);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetControlledSubstancesAsync()
        {
            var data = await _unitOfWork.RawMaterials.GetControlledSubstancesAsync();
            return _mapper.Map<IEnumerable<RawMaterialDto>>(data);
        }

        public async Task<bool> IsMaterialCodeExistsAsync(string materialCode)
        {
            return await _unitOfWork.RawMaterials.IsMaterialCodeExistsAsync(materialCode);
        }

        public async Task CreateAsync(CreateRawMaterialDto dto)
        {
            var entity = _mapper.Map<RawMaterial>(dto);
            await _unitOfWork.RawMaterials.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateRawMaterialDto dto)
        {
            var entity = await _unitOfWork.RawMaterials.GetByIdAsync(dto.RawMaterialId);

            if (entity == null)
                throw new Exception("Raw Material not found.");

            _mapper.Map(dto, entity);

            _unitOfWork.RawMaterials.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.RawMaterials.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Raw Material not found.");

            _unitOfWork.RawMaterials.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}