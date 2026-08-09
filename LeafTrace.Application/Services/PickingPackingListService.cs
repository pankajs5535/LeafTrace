using AutoMapper;
using LeafTrace.Application.DTOs.PickingPackingListDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class PickingPackingListService : IPickingPackingListService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PickingPackingListService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PickingPackingListDto>> GetAllAsync()
        {
            var data = await _unitOfWork.PickingPackingLists.GetAllAsync();
            return _mapper.Map<IEnumerable<PickingPackingListDto>>(data);
        }

        public async Task<PickingPackingListDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.PickingPackingLists.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<PickingPackingListDto>(data);
        }

        public async Task<IEnumerable<PickingPackingListDto>> GetByPickerAsync(int pickerId)
        {
            var data = await _unitOfWork.PickingPackingLists.GetByPickerAsync(pickerId);
            return _mapper.Map<IEnumerable<PickingPackingListDto>>(data);
        }

        public async Task<IEnumerable<PickingPackingListDto>> GetByStatusAsync(string status)
        {
            var data = await _unitOfWork.PickingPackingLists.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<PickingPackingListDto>>(data);
        }

        public async Task<IEnumerable<PickingPackingListDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.PickingPackingLists.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<PickingPackingListDto>>(data);
        }

        public async Task CreateAsync(CreatePickingPackingListDto dto)
        {
            var entity = _mapper.Map<PickingPackingList>(dto);
            await _unitOfWork.PickingPackingLists.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdatePickingPackingListDto dto)
        {
            var entity = await _unitOfWork.PickingPackingLists.GetByIdAsync(dto.PickPackId);

            if (entity == null)
                throw new Exception("Record not found");

            _mapper.Map(dto, entity);

            _unitOfWork.PickingPackingLists.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.PickingPackingLists.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Record not found");

            _unitOfWork.PickingPackingLists.Delete(entity);
            await _unitOfWork.SaveAsync();
        }


        public async Task<PickingPackingListDto?> GetByNumberAsync(string number)
        {
            var data = await _unitOfWork.PickingPackingLists.GetByNumberAsync(number);
            return data == null ? null : _mapper.Map<PickingPackingListDto>(data);
        }

        public async Task<IEnumerable<PickingPackingListDto>> GetBySalesOrderAsync(int salesOrderId)
        {
            var data = await _unitOfWork.PickingPackingLists.GetBySalesOrderAsync(salesOrderId);
            return _mapper.Map<IEnumerable<PickingPackingListDto>>(data);
        }

        public async Task<IEnumerable<PickingPackingListDto>> GetByProductAsync(int productId)
        {
            var data = await _unitOfWork.PickingPackingLists.GetByProductAsync(productId);
            return _mapper.Map<IEnumerable<PickingPackingListDto>>(data);
        }

        public async Task<IEnumerable<PickingPackingListDto>> GetReadyForDispatchAsync()
        {
            var data = await _unitOfWork.PickingPackingLists.GetReadyForDispatchAsync();
            return _mapper.Map<IEnumerable<PickingPackingListDto>>(data);
        }

        public async Task<bool> IsPickPackNumberExistsAsync(string number)
        {
            return await _unitOfWork.PickingPackingLists.IsPickPackNumberExistsAsync(number);
        }
    }
}