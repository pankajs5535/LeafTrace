using AutoMapper;
using LeafTrace.Application.DTOs.BatchTrackTraceDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class BatchTrackTraceService : IBatchTrackTraceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BatchTrackTraceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BatchTrackTraceDto>> GetAllAsync()
        {
            var data = await _unitOfWork.BatchTrackTraces.GetAllAsync();
            return _mapper.Map<IEnumerable<BatchTrackTraceDto>>(data);
        }

        public async Task<BatchTrackTraceDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.BatchTrackTraces.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<BatchTrackTraceDto>(data);
        }

        public async Task<BatchTrackTraceDto?> GetByTraceNumberAsync(string traceNumber)
        {
            var data = await _unitOfWork.BatchTrackTraces.GetByTraceNumberAsync(traceNumber);
            return data == null ? null : _mapper.Map<BatchTrackTraceDto>(data);
        }

        public async Task<IEnumerable<BatchTrackTraceDto>> GetByBatchAsync(string batchNumber)
        {
            var data = await _unitOfWork.BatchTrackTraces.GetByBatchAsync(batchNumber);
            return _mapper.Map<IEnumerable<BatchTrackTraceDto>>(data);
        }

        public async Task<IEnumerable<BatchTrackTraceDto>> GetByProductAsync(int productId)
        {
            var data = await _unitOfWork.BatchTrackTraces.GetByProductAsync(productId);
            return _mapper.Map<IEnumerable<BatchTrackTraceDto>>(data);
        }

        public async Task<IEnumerable<BatchTrackTraceDto>> GetByProductionOrderAsync(int productionOrderId)
        {
            var data = await _unitOfWork.BatchTrackTraces.GetByProductionOrderAsync(productionOrderId);
            return _mapper.Map<IEnumerable<BatchTrackTraceDto>>(data);
        }

        public async Task<IEnumerable<BatchTrackTraceDto>> GetByCustomerAsync(int customerId)
        {
            var data = await _unitOfWork.BatchTrackTraces.GetByCustomerAsync(customerId);
            return _mapper.Map<IEnumerable<BatchTrackTraceDto>>(data);
        }

        public async Task<IEnumerable<BatchTrackTraceDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.BatchTrackTraces.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<BatchTrackTraceDto>>(data);
        }

        public async Task<IEnumerable<BatchTrackTraceDto>> GetRecalledAsync()
        {
            var data = await _unitOfWork.BatchTrackTraces.GetRecalledAsync();
            return _mapper.Map<IEnumerable<BatchTrackTraceDto>>(data);
        }

        public async Task<IEnumerable<BatchTrackTraceDto>> GetDestroyedAsync()
        {
            var data = await _unitOfWork.BatchTrackTraces.GetDestroyedAsync();
            return _mapper.Map<IEnumerable<BatchTrackTraceDto>>(data);
        }

        public async Task<bool> IsTraceNumberExistsAsync(string traceNumber)
        {
            return await _unitOfWork.BatchTrackTraces.IsTraceNumberExistsAsync(traceNumber);
        }

        public async Task CreateAsync(CreateBatchTrackTraceDto dto)
        {
            var entity = _mapper.Map<BatchTrackTrace>(dto);
            await _unitOfWork.BatchTrackTraces.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateBatchTrackTraceDto dto)
        {
            var entity = await _unitOfWork.BatchTrackTraces.GetByIdAsync(dto.TraceId);

            if (entity == null)
                throw new Exception("Batch trace not found.");

            _mapper.Map(dto, entity);

            _unitOfWork.BatchTrackTraces.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.BatchTrackTraces.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Batch trace not found.");

            _unitOfWork.BatchTrackTraces.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}