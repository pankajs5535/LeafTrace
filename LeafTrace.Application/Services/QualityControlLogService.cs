using AutoMapper;
using LeafTrace.Application.DTOs.QualityControlLogDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class QualityControlLogService : IQualityControlLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QualityControlLogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QualityControlLogDto>> GetAllAsync()
        {
            var data = await _unitOfWork.QualityControlLogs.GetAllAsync();
            return _mapper.Map<IEnumerable<QualityControlLogDto>>(data);
        }

        public async Task<QualityControlLogDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.QualityControlLogs.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<QualityControlLogDto>(data);
        }

        public async Task<QualityControlLogDto?> GetByReferenceAsync(string reference)
        {
            var data = await _unitOfWork.QualityControlLogs.GetByReferenceAsync(reference);
            return data == null ? null : _mapper.Map<QualityControlLogDto>(data);
        }

        public async Task<IEnumerable<QualityControlLogDto>> GetByProductionOrderAsync(int productionOrderId)
        {
            var data = await _unitOfWork.QualityControlLogs.GetByProductionOrderAsync(productionOrderId);
            return _mapper.Map<IEnumerable<QualityControlLogDto>>(data);
        }

        public async Task<IEnumerable<QualityControlLogDto>> GetByProductAsync(int productId)
        {
            var data = await _unitOfWork.QualityControlLogs.GetByProductAsync(productId);
            return _mapper.Map<IEnumerable<QualityControlLogDto>>(data);
        }

        public async Task<IEnumerable<QualityControlLogDto>> GetByRawMaterialAsync(int rawMaterialId)
        {
            var data = await _unitOfWork.QualityControlLogs.GetByRawMaterialAsync(rawMaterialId);
            return _mapper.Map<IEnumerable<QualityControlLogDto>>(data);
        }

        public async Task<IEnumerable<QualityControlLogDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.QualityControlLogs.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<QualityControlLogDto>>(data);
        }

        public async Task<IEnumerable<QualityControlLogDto>> GetReleasedAsync()
        {
            var data = await _unitOfWork.QualityControlLogs.GetReleasedAsync();
            return _mapper.Map<IEnumerable<QualityControlLogDto>>(data);
        }

        public async Task<IEnumerable<QualityControlLogDto>> GetPendingAsync()
        {
            var data = await _unitOfWork.QualityControlLogs.GetPendingAsync();
            return _mapper.Map<IEnumerable<QualityControlLogDto>>(data);
        }

        public async Task<IEnumerable<QualityControlLogDto>> GetByResultAsync(string result)
        {
            var data = await _unitOfWork.QualityControlLogs.GetByResultAsync(result);
            return _mapper.Map<IEnumerable<QualityControlLogDto>>(data);
        }

        public async Task<bool> IsReferenceExistsAsync(string reference)
        {
            return await _unitOfWork.QualityControlLogs.IsReferenceExistsAsync(reference);
        }

        public async Task CreateAsync(CreateQualityControlLogDto dto)
        {
            var entity = _mapper.Map<QualityControlLog>(dto);
            await _unitOfWork.QualityControlLogs.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateQualityControlLogDto dto)
        {
            var entity = await _unitOfWork.QualityControlLogs.GetByIdAsync(dto.Qcid);

            if (entity == null)
                throw new Exception("Quality Control Log not found.");

            _mapper.Map(dto, entity);

            _unitOfWork.QualityControlLogs.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.QualityControlLogs.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Quality Control Log not found.");

            _unitOfWork.QualityControlLogs.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}