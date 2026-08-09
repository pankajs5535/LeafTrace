using AutoMapper;
using LeafTrace.Application.DTOs.SupplierDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var data = await _unitOfWork.Suppliers.GetAllAsync();
            return _mapper.Map<IEnumerable<SupplierDto>>(data);
        }

        public async Task<SupplierDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.Suppliers.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<SupplierDto>(data);
        }

        public async Task AddAsync(CreateSupplierDto dto)
        {
            var entity = _mapper.Map<Supplier>(dto);
            await _unitOfWork.Suppliers.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task CreateAsync(CreateSupplierDto dto)
        {
            var entity = _mapper.Map<Supplier>(dto);
            await _unitOfWork.Suppliers.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateSupplierDto dto)
        {
            var entity = await _unitOfWork.Suppliers.GetByIdAsync(dto.SupplierId);
            if (entity == null) return;

            _mapper.Map(dto, entity);
            _unitOfWork.Suppliers.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Suppliers.GetByIdAsync(id);
            if (entity == null) return;

            _unitOfWork.Suppliers.Delete(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteMultipleAsync(DeleteMultipleSuppliersDto dto)
        {
            var suppliers = await _unitOfWork.Suppliers.GetAllAsync();
            var toDelete = suppliers.Where(x => dto.Ids.Contains(x.SupplierId)).ToList();

            foreach (var item in toDelete)
            {
                _unitOfWork.Suppliers.Delete(item);
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task<SupplierDto?> GetByCodeAsync(string code)
        {
            var data = await _unitOfWork.Suppliers.FindAsync(x => x.SupplierCode == code);
            return _mapper.Map<SupplierDto?>(data.FirstOrDefault());
        }

        public async Task<IEnumerable<SupplierDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.Suppliers.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<SupplierDto>>(data);
        }

        public async Task<IEnumerable<SupplierDto>> GetByTypeAsync(string type)
        {
            var data = await _unitOfWork.Suppliers.FindAsync(x => x.SupplierType == type);
            return _mapper.Map<IEnumerable<SupplierDto>>(data);
        }

        public async Task<IEnumerable<SupplierDto>> GetApprovedSuppliersAsync()
        {
            var data = await _unitOfWork.Suppliers.FindAsync(x => x.IsApproved);
            return _mapper.Map<IEnumerable<SupplierDto>>(data);
        }

        public async Task<IEnumerable<SupplierDto>> GetActiveSuppliersAsync()
        {
            var data = await _unitOfWork.Suppliers.FindAsync(x => x.IsActive);
            return _mapper.Map<IEnumerable<SupplierDto>>(data);
        }

        public async Task<IEnumerable<SupplierDto>> GetInactiveSuppliersAsync()
        {
            var data = await _unitOfWork.Suppliers.FindAsync(x => !x.IsActive);
            return _mapper.Map<IEnumerable<SupplierDto>>(data);
        }

        public async Task<IEnumerable<SupplierDto>> GetByDateRangeAsync(DateTime from, DateTime to)
        {
            var data = await _unitOfWork.Suppliers.FindAsync(x => x.CreatedAt >= from && x.CreatedAt <= to);
            return _mapper.Map<IEnumerable<SupplierDto>>(data);
        }

        public async Task<bool> IsSupplierCodeExistsAsync(string code)
        {
            return await _unitOfWork.Suppliers.ExistsAsync(x => x.SupplierCode == code);
        }
        public async Task<bool> IsGstNumberExistsAsync(string gst)
        {
            return await _unitOfWork.Suppliers
                .ExistsAsync(x => x.Gstnumber == gst);
        }

        public async Task<bool> IsPanNumberExistsAsync(string pan)
        {
            return await _unitOfWork.Suppliers
                .ExistsAsync(x => x.Pannumber == pan);
        }

        public Task<IEnumerable<SupplierDto>> GetByGSTAsync(string gst)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SupplierDto>> GetByPANAsync(string pan)
        {
            throw new NotImplementedException();
        }
    }
}