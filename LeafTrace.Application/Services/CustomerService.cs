using AutoMapper;
using LeafTrace.Application.DTOs.CustomerDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var data = await _unitOfWork.Customers.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(data);
        }

        public async Task<CustomerDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.Customers.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<CustomerDto>(data);
        }

        public async Task CreateAsync(CreateCustomerDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);
            await _unitOfWork.Customers.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateCustomerDto dto)
        {
            var entity = await _unitOfWork.Customers.GetByIdAsync(dto.CustomerId);
            if (entity == null) return;

            _mapper.Map(dto, entity);
            _unitOfWork.Customers.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Customers.GetByIdAsync(id);
            if (entity == null) return;

            _unitOfWork.Customers.Delete(entity);
            await _unitOfWork.SaveAsync();
        }

        // ✅ FIXED (use repo method)
        public async Task<CustomerDto?> GetByCodeAsync(string code)
        {
            var data = await _unitOfWork.Customers.GetByCodeAsync(code);
            return data == null ? null : _mapper.Map<CustomerDto>(data);
        }

        // ✅ FIXED (use repo method)
        public async Task<IEnumerable<CustomerDto>> GetByTypeAsync(string type)
        {
            var data = await _unitOfWork.Customers.GetByTypeAsync(type);
            return _mapper.Map<IEnumerable<CustomerDto>>(data);
        }

        public async Task<IEnumerable<CustomerDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.Customers.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<CustomerDto>>(data);
        }

        public async Task<IEnumerable<CustomerDto>> GetActiveAsync()
        {
            var data = await _unitOfWork.Customers.GetActiveAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(data);
        }

        public async Task<IEnumerable<CustomerDto>> GetInactiveAsync()
        {
            var data = await _unitOfWork.Customers.GetInactiveAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(data);
        }

        public async Task<bool> IsCustomerCodeExistsAsync(string code)
        {
            return await _unitOfWork.Customers.IsCustomerCodeExistsAsync(code);
        }

        public Task<IEnumerable<CustomerDto>> GetByRegionAsync(string region)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDto>> GetByZoneAsync(string zone)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDto>> GetBySalesRepAsync(int salesRepId)
        {
            throw new NotImplementedException();
        }
    }
}