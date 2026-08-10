using AutoMapper;
using LeafTrace.Application.DTOs.MachineMasterDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class MachineMasterService : IMachineMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MachineMasterService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MachineMasterDto>> GetAllAsync()
        {
            var data = await _unitOfWork.MachineMasters.GetAllAsync();
            return _mapper.Map<IEnumerable<MachineMasterDto>>(data);
        }

        public async Task<MachineMasterDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.MachineMasters.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<MachineMasterDto>(data);
        }

        public async Task<MachineMasterDto?> GetByCodeAsync(string code)
        {
            var data = await _unitOfWork.MachineMasters.GetByCodeAsync(code);
            return data == null ? null : _mapper.Map<MachineMasterDto>(data);
        }

        public async Task<IEnumerable<MachineMasterDto>> GetByTypeAsync(string type)
        {
            var data = await _unitOfWork.MachineMasters.GetByTypeAsync(type);
            return _mapper.Map<IEnumerable<MachineMasterDto>>(data);
        }

        public async Task<IEnumerable<MachineMasterDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.MachineMasters.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<MachineMasterDto>>(data);
        }

        public async Task<IEnumerable<MachineMasterDto>> GetActiveAsync()
        {
            var data = await _unitOfWork.MachineMasters.GetActiveAsync();
            return _mapper.Map<IEnumerable<MachineMasterDto>>(data);
        }

        public async Task<IEnumerable<MachineMasterDto>> GetInactiveAsync()
        {
            var data = await _unitOfWork.MachineMasters.GetInactiveAsync();
            return _mapper.Map<IEnumerable<MachineMasterDto>>(data);
        }

        public async Task<IEnumerable<MachineMasterDto>> GetByStatusAsync(string status)
        {
            var data = await _unitOfWork.MachineMasters.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<MachineMasterDto>>(data);
        }

        public async Task<IEnumerable<MachineMasterDto>> GetMaintenanceDueAsync()
        {
            var data = await _unitOfWork.MachineMasters.GetMaintenanceDueAsync();
            return _mapper.Map<IEnumerable<MachineMasterDto>>(data);
        }

        public async Task<IEnumerable<MachineMasterDto>> GetByPlantAsync(string plant)
        {
            var data = await _unitOfWork.MachineMasters.GetByPlantAsync(plant);
            return _mapper.Map<IEnumerable<MachineMasterDto>>(data);
        }

        public async Task<bool> IsMachineCodeExistsAsync(string machineCode)
        {
            return await _unitOfWork.MachineMasters.IsMachineCodeExistsAsync(machineCode);
        }

        public async Task CreateAsync(CreateMachineMasterDto dto)
        {
            var entity = _mapper.Map<MachineMaster>(dto);
            await _unitOfWork.MachineMasters.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateMachineMasterDto dto)
        {
            var entity = await _unitOfWork.MachineMasters.GetByIdAsync(dto.MachineId);

            if (entity == null)
                throw new Exception("Machine not found.");

            _mapper.Map(dto, entity);

            _unitOfWork.MachineMasters.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.MachineMasters.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Machine not found.");

            _unitOfWork.MachineMasters.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}