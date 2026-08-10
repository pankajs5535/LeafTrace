using AutoMapper;
using LeafTrace.Application.DTOs.BillOfMaterialsBomDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class BillOfMaterialsBomService : IBillOfMaterialsBomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BillOfMaterialsBomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetAllAsync()
        {
            var data = await _unitOfWork.BillOfMaterialsBoms.GetAllAsync();
            return _mapper.Map<IEnumerable<BillOfMaterialsBomDto>>(data);
        }

        public async Task<BillOfMaterialsBomDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.BillOfMaterialsBoms.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<BillOfMaterialsBomDto>(data);
        }

        public async Task<BillOfMaterialsBomDto?> GetByVersionAsync(string version)
        {
            var data = await _unitOfWork.BillOfMaterialsBoms.GetByVersionAsync(version);
            return data == null ? null : _mapper.Map<BillOfMaterialsBomDto>(data);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetByProductAsync(int productId)
        {
            var data = await _unitOfWork.BillOfMaterialsBoms.GetByProductAsync(productId);
            return _mapper.Map<IEnumerable<BillOfMaterialsBomDto>>(data);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetByRawMaterialAsync(int rawMaterialId)
        {
            var data = await _unitOfWork.BillOfMaterialsBoms.GetByRawMaterialAsync(rawMaterialId);
            return _mapper.Map<IEnumerable<BillOfMaterialsBomDto>>(data);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.BillOfMaterialsBoms.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<BillOfMaterialsBomDto>>(data);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetActiveAsync()
        {
            var data = await _unitOfWork.BillOfMaterialsBoms.GetActiveAsync();
            return _mapper.Map<IEnumerable<BillOfMaterialsBomDto>>(data);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetByEffectiveDateAsync(DateOnly fromDate, DateOnly toDate)
        {
            var data = await _unitOfWork.BillOfMaterialsBoms.GetByEffectiveDateAsync(fromDate, toDate);
            return _mapper.Map<IEnumerable<BillOfMaterialsBomDto>>(data);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetCriticalComponentsAsync()
        {
            var data = await _unitOfWork.BillOfMaterialsBoms.GetCriticalComponentsAsync();
            return _mapper.Map<IEnumerable<BillOfMaterialsBomDto>>(data);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetSubstituteAllowedAsync()
        {
            var data = await _unitOfWork.BillOfMaterialsBoms.GetSubstituteAllowedAsync();
            return _mapper.Map<IEnumerable<BillOfMaterialsBomDto>>(data);
        }

        public async Task<bool> IsBomVersionExistsAsync(string version)
        {
            return await _unitOfWork.BillOfMaterialsBoms.IsBomVersionExistsAsync(version);
        }

        public async Task CreateAsync(CreateBillOfMaterialsBomDto dto)
        {
            var entity = _mapper.Map<BillOfMaterialsBom>(dto);
            await _unitOfWork.BillOfMaterialsBoms.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateBillOfMaterialsBomDto dto)
        {
            var entity = await _unitOfWork.BillOfMaterialsBoms.GetByIdAsync(dto.Bomid);

            if (entity == null)
                throw new Exception("BOM not found.");

            _mapper.Map(dto, entity);

            _unitOfWork.BillOfMaterialsBoms.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.BillOfMaterialsBoms.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("BOM not found.");

            _unitOfWork.BillOfMaterialsBoms.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}