using LeafTrace.Application.Interfaces.IRepositories;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Persistence.Data;
using LeafTrace.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeafTrace.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ISupplierRepository Suppliers { get; }

        public IRawMaterialRepository RawMaterials { get; }

        public IProductRepository Products { get; }

        public IBillOfMaterialsBomRepository BillOfMaterialsBoms { get; }

        public IMachineMasterRepository MachineMasters { get; }

        public IProductionOrderRepository ProductionOrders { get; }

        public IWarehouseBinRepository WarehouseBins { get; }

        public IWarehouseInventoryRepository WarehouseInventories { get; }

        public ICustomerRepository Customers { get; }

        public ISalesOrderRepository SalesOrders { get; }

        public IQualityControlLogRepository QualityControlLogs { get; }

        public IExciseStampRepository ExciseStamps { get; }

        public IPickingPackingListRepository PickingPackingLists { get; }

        public IShipmentLogRepository ShipmentLogs { get; }

        public IBatchTrackTraceRepository BatchTrackTraces { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Suppliers = new SupplierRepository(context);
            RawMaterials = new RawMaterialRepository(context);
            Products = new ProductRepository(context);
            BillOfMaterialsBoms = new BillOfMaterialsBomRepository(context);
            MachineMasters = new MachineMasterRepository(context);
            ProductionOrders = new ProductionOrderRepository(context);
            WarehouseBins = new WarehouseBinRepository(context);
            WarehouseInventories = new WarehouseInventoryRepository(context);
            Customers = new CustomerRepository(context);
            SalesOrders = new SalesOrderRepository(context);
            QualityControlLogs = new QualityControlLogRepository(context);
            ExciseStamps = new ExciseStampRepository(context);
            PickingPackingLists = new PickingPackingListRepository(context);
            ShipmentLogs = new ShipmentLogRepository(context);
            BatchTrackTraces = new BatchTrackTraceRepository(context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
