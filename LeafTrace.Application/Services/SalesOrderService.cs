using AutoMapper;
using LeafTrace.Application.DTOs.SalesOrderDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SalesOrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SalesOrderDto>> GetAllAsync()
        {
            var data = await _unitOfWork.SalesOrders.GetAllAsync();
            return _mapper.Map<IEnumerable<SalesOrderDto>>(data);
        }

        public async Task<SalesOrderDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.SalesOrders.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<SalesOrderDto>(data);
        }

        public async Task<SalesOrderDto?> GetByOrderNumberAsync(string orderNumber)
        {
            var data = await _unitOfWork.SalesOrders.GetByOrderNumberAsync(orderNumber);
            return data == null ? null : _mapper.Map<SalesOrderDto>(data);
        }

        public async Task<IEnumerable<SalesOrderDto>> GetByCustomerAsync(int customerId)
        {
            var data = await _unitOfWork.SalesOrders.GetByCustomerAsync(customerId);
            return _mapper.Map<IEnumerable<SalesOrderDto>>(data);
        }

        public async Task<IEnumerable<SalesOrderDto>> GetByProductAsync(int productId)
        {
            var data = await _unitOfWork.SalesOrders.GetByProductAsync(productId);
            return _mapper.Map<IEnumerable<SalesOrderDto>>(data);
        }

        public async Task<IEnumerable<SalesOrderDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.SalesOrders.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<SalesOrderDto>>(data);
        }

        public async Task<IEnumerable<SalesOrderDto>> GetByStatusAsync(string status)
        {
            var data = await _unitOfWork.SalesOrders.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<SalesOrderDto>>(data);
        }

        public async Task<IEnumerable<SalesOrderDto>> GetByPaymentStatusAsync(string paymentStatus)
        {
            var data = await _unitOfWork.SalesOrders.GetByPaymentStatusAsync(paymentStatus);
            return _mapper.Map<IEnumerable<SalesOrderDto>>(data);
        }

        public async Task<IEnumerable<SalesOrderDto>> GetByDateRangeAsync(DateOnly fromDate, DateOnly toDate)
        {
            var data = await _unitOfWork.SalesOrders.GetByDateRangeAsync(fromDate, toDate);
            return _mapper.Map<IEnumerable<SalesOrderDto>>(data);
        }

        public async Task<IEnumerable<SalesOrderDto>> GetApprovedOrdersAsync()
        {
            var data = await _unitOfWork.SalesOrders.GetApprovedOrdersAsync();
            return _mapper.Map<IEnumerable<SalesOrderDto>>(data);
        }

        public async Task<bool> IsOrderNumberExistsAsync(string orderNumber)
        {
            return await _unitOfWork.SalesOrders.IsOrderNumberExistsAsync(orderNumber);
        }

        public async Task CreateAsync(CreateSalesOrderDto dto)
        {
            var entity = _mapper.Map<SalesOrder>(dto);
            await _unitOfWork.SalesOrders.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateSalesOrderDto dto)
        {
            var entity = await _unitOfWork.SalesOrders.GetByIdAsync(dto.SalesOrderId);

            if (entity == null)
                throw new Exception("Sales Order not found.");

            _mapper.Map(dto, entity);

            _unitOfWork.SalesOrders.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.SalesOrders.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Sales Order not found.");

            _unitOfWork.SalesOrders.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}