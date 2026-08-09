using AutoMapper;
using LeafTrace.Application.DTOs.ShipmentLogDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class ShipmentLogService : IShipmentLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShipmentLogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShipmentLogDto>> GetAllAsync()
        {
            var data = await _unitOfWork.ShipmentLogs.GetAllAsync();
            return _mapper.Map<IEnumerable<ShipmentLogDto>>(data);
        }

        public async Task<ShipmentLogDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.ShipmentLogs.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<ShipmentLogDto>(data);
        }

        public async Task<ShipmentLogDto?> GetByShipmentNumberAsync(string shipmentNumber)
        {
            var data = await _unitOfWork.ShipmentLogs.GetByShipmentNumberAsync(shipmentNumber);
            return data == null ? null : _mapper.Map<ShipmentLogDto>(data);
        }

        public async Task<IEnumerable<ShipmentLogDto>> GetBySalesOrderAsync(int salesOrderId)
        {
            var data = await _unitOfWork.ShipmentLogs.GetBySalesOrderAsync(salesOrderId);
            return _mapper.Map<IEnumerable<ShipmentLogDto>>(data);
        }

        public async Task<IEnumerable<ShipmentLogDto>> GetByPickPackAsync(int pickPackId)
        {
            var data = await _unitOfWork.ShipmentLogs.GetByPickPackAsync(pickPackId);
            return _mapper.Map<IEnumerable<ShipmentLogDto>>(data);
        }

        public async Task<IEnumerable<ShipmentLogDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.ShipmentLogs.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<ShipmentLogDto>>(data);
        }

        public async Task<IEnumerable<ShipmentLogDto>> GetByStatusAsync(string status)
        {
            var data = await _unitOfWork.ShipmentLogs.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<ShipmentLogDto>>(data);
        }

        public async Task<IEnumerable<ShipmentLogDto>> GetDeliveredAsync()
        {
            var data = await _unitOfWork.ShipmentLogs.GetDeliveredAsync();
            return _mapper.Map<IEnumerable<ShipmentLogDto>>(data);
        }

        public async Task<IEnumerable<ShipmentLogDto>> GetPendingDeliveriesAsync()
        {
            var data = await _unitOfWork.ShipmentLogs.GetPendingDeliveriesAsync();
            return _mapper.Map<IEnumerable<ShipmentLogDto>>(data);
        }

        public async Task<IEnumerable<ShipmentLogDto>> GetByTransporterAsync(string transporter)
        {
            var data = await _unitOfWork.ShipmentLogs.GetByTransporterAsync(transporter);
            return _mapper.Map<IEnumerable<ShipmentLogDto>>(data);
        }

        public async Task<bool> IsShipmentNumberExistsAsync(string shipmentNumber)
        {
            return await _unitOfWork.ShipmentLogs.IsShipmentNumberExistsAsync(shipmentNumber);
        }

        public async Task CreateAsync(CreateShipmentLogDto dto)
        {
            var entity = _mapper.Map<ShipmentLog>(dto);
            await _unitOfWork.ShipmentLogs.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateShipmentLogDto dto)
        {
            var entity = await _unitOfWork.ShipmentLogs.GetByIdAsync(dto.ShipmentId);

            if (entity == null)
                throw new Exception("Shipment not found.");

            _mapper.Map(dto, entity);

            _unitOfWork.ShipmentLogs.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.ShipmentLogs.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Shipment not found.");

            _unitOfWork.ShipmentLogs.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}