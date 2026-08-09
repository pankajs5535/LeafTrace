using AutoMapper;
using LeafTrace.Application.DTOs.ProductDtos;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var data = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.Products.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<ProductDto>(data);
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            await _unitOfWork.Products.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateProductDto dto)
        {
            var entity = await _unitOfWork.Products.GetByIdAsync(dto.ProductId);
            if (entity == null) return;

            _mapper.Map(dto, entity);
            _unitOfWork.Products.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Products.GetByIdAsync(id);
            if (entity == null) return;

            _unitOfWork.Products.Delete(entity);
            await _unitOfWork.SaveAsync();
        }

        // ✅ FIXED (use repo method if exists)
        public async Task<ProductDto?> GetByCodeAsync(string code)
        {
            var data = await _unitOfWork.Products.GetByCodeAsync(code);
            return data == null ? null : _mapper.Map<ProductDto>(data);
        }

        // ❌ REMOVED WRONG ProductType (not in entity)
        public Task<IEnumerable<ProductDto>> GetByTypeAsync(string type)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> SearchAsync(string keyword)
        {
            var data = await _unitOfWork.Products.SearchAsync(keyword);
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        // ✅ USE repo (better than FindAsync)
        public async Task<IEnumerable<ProductDto>> GetActiveAsync()
        {
            var data = await _unitOfWork.Products.GetActiveAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        public async Task<IEnumerable<ProductDto>> GetInactiveAsync()
        {
            var data = await _unitOfWork.Products.GetInactiveAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        public async Task<bool> IsProductCodeExistsAsync(string code)
        {
            return await _unitOfWork.Products.IsProductCodeExistsAsync(code);
        }

        // ✅ ALL EXTRA METHODS (repo आधारित)

        public async Task<IEnumerable<ProductDto>> GetByBrandAsync(string brand)
        {
            var data = await _unitOfWork.Products.GetByBrandAsync(brand);
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        public async Task<IEnumerable<ProductDto>> GetByCategoryAsync(string category)
        {
            var data = await _unitOfWork.Products.GetByCategoryAsync(category);
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        public async Task<IEnumerable<ProductDto>> GetByDateRangeAsync(DateTime from, DateTime to)
        {
            var data = await _unitOfWork.Products.GetByDateRangeAsync(from, to);
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        public async Task<IEnumerable<ProductDto>> GetExportProductsAsync()
        {
            var data = await _unitOfWork.Products.GetExportProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        public async Task<IEnumerable<ProductDto>> GetHealthWarningProductsAsync()
        {
            var data = await _unitOfWork.Products.GetHealthWarningProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        public async Task<IEnumerable<ProductDto>> GetDiscontinuedProductsAsync()
        {
            var data = await _unitOfWork.Products.GetDiscontinuedProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }
    }
}