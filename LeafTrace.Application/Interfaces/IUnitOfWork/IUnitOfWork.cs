using LeafTrace.Application.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeafTrace.Application.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISupplierRepository Suppliers { get; }

        IRawMaterialRepository RawMaterials { get; }

        IProductRepository Products { get; }

        IBillOfMaterialsBomRepository BillOfMaterialsBoms { get; }

        IMachineMasterRepository MachineMasters { get; }

        IProductionOrderRepository ProductionOrders { get; }

        IWarehouseBinRepository WarehouseBins { get; }

        IWarehouseInventoryRepository WarehouseInventories { get; }

        ICustomerRepository Customers { get; }

        ISalesOrderRepository SalesOrders { get; }

        IQualityControlLogRepository QualityControlLogs { get; }

        IExciseStampRepository ExciseStamps { get; }

        IPickingPackingListRepository PickingPackingLists { get; }

        IShipmentLogRepository ShipmentLogs { get; }

        IBatchTrackTraceRepository BatchTrackTraces { get; }

        Task<int> SaveAsync();
    }
}
