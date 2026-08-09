using AutoMapper;
using LeafTrace.Domain.Entities;
using LeafTrace.Application.DTOs.SupplierDtos;
using LeafTrace.Application.DTOs.ProductDtos;
using LeafTrace.Application.DTOs.CustomerDtos;
using LeafTrace.Application.DTOs.RawMaterialDtos;
using LeafTrace.Application.DTOs.SalesOrderDtos;
using LeafTrace.Application.DTOs.ProductionOrderDtos;
using LeafTrace.Application.DTOs.WarehouseInventoryDtos;
using LeafTrace.Application.DTOs.WarehouseBinDtos;
using LeafTrace.Application.DTOs.BatchTrackTraceDtos;
using LeafTrace.Application.DTOs.BillOfMaterialsBomDtos;
using LeafTrace.Application.DTOs.ExciseStampDtos;
using LeafTrace.Application.DTOs.MachineMasterDtos;
using LeafTrace.Application.DTOs.PickingPackingListDtos;
using LeafTrace.Application.DTOs.ShipmentLogDtos;
using LeafTrace.Application.DTOs.QualityControlLogDtos;

namespace LeafTrace.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Supplier
            CreateMap<Supplier, SupplierDto>();
            CreateMap<CreateSupplierDto, Supplier>();
            CreateMap<UpdateSupplierDto, Supplier>();

            // Product
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

            // Customer
            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();

            // Raw Material
            CreateMap<RawMaterial, RawMaterialDto>();
            CreateMap<CreateRawMaterialDto, RawMaterial>();
            CreateMap<UpdateRawMaterialDto, RawMaterial>();

            // Sales Order
            CreateMap<SalesOrder, SalesOrderDto>();
            CreateMap<CreateSalesOrderDto, SalesOrder>();
            CreateMap<UpdateSalesOrderDto, SalesOrder>();

            // Production Order
            CreateMap<ProductionOrder, ProductionOrderDto>();
            CreateMap<CreateProductionOrderDto, ProductionOrder>();
            CreateMap<UpdateProductionOrderDto, ProductionOrder>();

            // Warehouse Inventory
            CreateMap<WarehouseInventory, WarehouseInventoryDto>();
            CreateMap<CreateWarehouseInventoryDto, WarehouseInventory>();
            CreateMap<UpdateWarehouseInventoryDto, WarehouseInventory>();

            // Warehouse Bin
            CreateMap<WarehouseBin, WarehouseBinDto>();
            CreateMap<CreateWarehouseBinDto, WarehouseBin>();
            CreateMap<UpdateWarehouseBinDto, WarehouseBin>();

            // Batch Track Trace
            CreateMap<BatchTrackTrace, BatchTrackTraceDto>();
            CreateMap<CreateBatchTrackTraceDto, BatchTrackTrace>();
            CreateMap<UpdateBatchTrackTraceDto, BatchTrackTrace>();

            // BOM
            CreateMap<BillOfMaterialsBom, BillOfMaterialsBomDto>();
            CreateMap<CreateBillOfMaterialsBomDto, BillOfMaterialsBom>();
            CreateMap<UpdateBillOfMaterialsBomDto, BillOfMaterialsBom>();

            // Excise Stamp
            CreateMap<ExciseStamp, ExciseStampDto>();
            CreateMap<CreateExciseStampDto, ExciseStamp>();
            CreateMap<UpdateExciseStampDto, ExciseStamp>();

            // Machine Master
            CreateMap<MachineMaster, MachineMasterDto>();
            CreateMap<CreateMachineMasterDto, MachineMaster>();
            CreateMap<UpdateMachineMasterDto, MachineMaster>();

            // Picking Packing
            CreateMap<PickingPackingList, PickingPackingListDto>();
            CreateMap<CreatePickingPackingListDto, PickingPackingList>();
            CreateMap<UpdatePickingPackingListDto, PickingPackingList>();

            // Shipment Log
            CreateMap<ShipmentLog, ShipmentLogDto>();
            CreateMap<CreateShipmentLogDto, ShipmentLog>();
            CreateMap<UpdateShipmentLogDto, ShipmentLog>();

            // Quality Control
            CreateMap<QualityControlLog, QualityControlLogDto>();
            CreateMap<CreateQualityControlLogDto, QualityControlLog>();
            CreateMap<UpdateQualityControlLogDto, QualityControlLog>();
        }
    }
}