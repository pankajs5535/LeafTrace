using AutoMapper;
using LeafTrace.Application.DTOs.ProductionOrderDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class ProductionOrderService : IProductionOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductionOrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductionOrderDto>> GetAllAsync()
        {
            var data = await _unitOfWork.ProductionOrders.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductionOrderDto>>(data);
        }

        public async Task<ProductionOrderDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.ProductionOrders.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<ProductionOrderDto>(data);
        }

        public async Task<ProductionOrderDto?> GetByOrderNumberAsync(string orderNumber)
        {
            var data = await _unitOfWork.ProductionOrders.GetByOrderNumberAsync(orderNumber);
            return data == null ? null : _mapper.Map<ProductionOrderDto>(data);
        }

        public async Task<IEnumerable<ProductionOrderDto>> GetByProductAsync(int productId)
        {
            var data = await _unitOfWork.ProductionOrders.GetByProductAsync(productId);
            return _mapper.Map<IEnumerable<ProductionOrderDto>>(data);
        }

        public async Task<IEnumerable<ProductionOrderDto>> GetByMachineAsync(int machineId)
        {
            var data = await _unitOfWork.ProductionOrders.GetByMachineAsync(machineId);
            return _mapper.Map<IEnumerable<ProductionOrderDto>>(data);
        }

        public async Task<IEnumerable<ProductionOrderDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.ProductionOrders.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<ProductionOrderDto>>(data);
        }

        public async Task<IEnumerable<ProductionOrderDto>> GetByStatusAsync(string status)
        {
            var data = await _unitOfWork.ProductionOrders.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<ProductionOrderDto>>(data);
        }

        public async Task<IEnumerable<ProductionOrderDto>> GetByPriorityAsync(byte priority)
        {
            var data = await _unitOfWork.ProductionOrders.GetByPriorityAsync(priority);
            return _mapper.Map<IEnumerable<ProductionOrderDto>>(data);
        }

        public async Task<IEnumerable<ProductionOrderDto>> GetByDateRangeAsync(DateOnly fromDate, DateOnly toDate)
        {
            var data = await _unitOfWork.ProductionOrders.GetByDateRangeAsync(fromDate, toDate);
            return _mapper.Map<IEnumerable<ProductionOrderDto>>(data);
        }

        public async Task<IEnumerable<ProductionOrderDto>> GetOpenOrdersAsync()
        {
            var data = await _unitOfWork.ProductionOrders.GetOpenOrdersAsync();
            return _mapper.Map<IEnumerable<ProductionOrderDto>>(data);
        }

        public async Task<bool> IsOrderNumberExistsAsync(string orderNumber)
        {
            return await _unitOfWork.ProductionOrders.IsOrderNumberExistsAsync(orderNumber);
        }

        public async Task CreateAsync(CreateProductionOrderDto dto)
        {
            var entity = _mapper.Map<ProductionOrder>(dto);
            await _unitOfWork.ProductionOrders.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateProductionOrderDto dto)
        {
            var entity = await _unitOfWork.ProductionOrders.GetByIdAsync(dto.ProductionOrderId);

            if (entity == null)
                throw new Exception("Production order not found.");

            _mapper.Map(dto, entity);

            _unitOfWork.ProductionOrders.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.ProductionOrders.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Production order not found.");

            _unitOfWork.ProductionOrders.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}