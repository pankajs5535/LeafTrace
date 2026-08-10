using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeafTrace.Application 
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // ================================
            // 🔹 SERVICE REGISTRATION (BUSINESS LOGIC)
            // ================================
            // Each service handles business logic for its module
            // Scoped lifetime → one instance per request

            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<IShipmentLogService, ShipmentLogService>();
            services.AddScoped<IWarehouseInventoryService, WarehouseInventoryService>();
            services.AddScoped<IWarehouseBinService, WarehouseBinService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductionOrderService, ProductionOrderService>();
            services.AddScoped<IPickingPackingListService, PickingPackingListService>();
            services.AddScoped<IQualityControlLogService, QualityControlLogService>();
            services.AddScoped<IRawMaterialService, RawMaterialService>();
            services.AddScoped<IBatchTrackTraceService, BatchTrackTraceService>();
            services.AddScoped<IBillOfMaterialsBomService, BillOfMaterialsBomService>();
            services.AddScoped<IExciseStampService, ExciseStampService>();
            services.AddScoped<IMachineMasterService, MachineMasterService>();

            // ================================
            // 🔹 AUTO MAPPER (OBJECT MAPPING)
            // ================================
            // Used to map Entity ↔ DTO
            // Will scan all mapping profiles in this project


            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // ================================
            // 🔹 VALIDATION (OPTIONAL - FUTURE)
            // ================================
            // FluentValidation will be added here later

            return services;
        }
    }
}