using Microsoft.Extensions.DependencyInjection;
using LeafTrace.Application.Interfaces.IServices;
using LeafTrace.Application.Services;

namespace LeafTrace.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // ✅ ALL SERVICES

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

            return services;
        }
    }
}