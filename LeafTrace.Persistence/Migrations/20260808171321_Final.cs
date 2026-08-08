using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeafTrace.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_Customers_CustomerId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_ExciseStamps_StampId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_ProductionOrders_ProductionOrderId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_Products_ProductId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_QualityControlLogs_QclogId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_RawMaterials_RawMaterialId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_SalesOrders_SalesOrderId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_ShipmentLogs_ShipmentId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_Suppliers_SupplierId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_WarehouseInventories_WarehouseInventoryId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BillOfMaterialsBoms_Products_ProductId",
                table: "BillOfMaterialsBoms");

            migrationBuilder.DropForeignKey(
                name: "FK_ExciseStamps_ProductionOrders_AppliedToProductionOrderId",
                table: "ExciseStamps");

            migrationBuilder.DropForeignKey(
                name: "FK_ExciseStamps_Products_ProductId",
                table: "ExciseStamps");

            migrationBuilder.DropForeignKey(
                name: "FK_ExciseStamps_WarehouseBins_StorageLocationBinId",
                table: "ExciseStamps");

            migrationBuilder.DropForeignKey(
                name: "FK_PickingPackingLists_Products_ProductId",
                table: "PickingPackingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_PickingPackingLists_SalesOrders_SalesOrderId",
                table: "PickingPackingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_PickingPackingLists_WarehouseBins_BinId",
                table: "PickingPackingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrders_BillOfMaterialsBoms_Bomid",
                table: "ProductionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrders_MachineMasters_MachineId",
                table: "ProductionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrders_Products_ProductId",
                table: "ProductionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityControlLogs_ProductionOrders_ProductionOrderId",
                table: "QualityControlLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityControlLogs_Products_ProductId",
                table: "QualityControlLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityControlLogs_RawMaterials_RawMaterialId",
                table: "QualityControlLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_Suppliers_PrimarySupplierId",
                table: "RawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Customers_CustomerId",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Products_ProductId",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentLogs_PickingPackingLists_PickPackId",
                table: "ShipmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentLogs_SalesOrders_SalesOrderId",
                table: "ShipmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseInventories_Products_ProductId",
                table: "WarehouseInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseInventories_RawMaterials_RawMaterialId",
                table: "WarehouseInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseInventories_WarehouseBins_BinId",
                table: "WarehouseInventories");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_Customers_CustomerId",
                table: "BatchTrackTraces",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_ExciseStamps_StampId",
                table: "BatchTrackTraces",
                column: "StampId",
                principalTable: "ExciseStamps",
                principalColumn: "StampId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_ProductionOrders_ProductionOrderId",
                table: "BatchTrackTraces",
                column: "ProductionOrderId",
                principalTable: "ProductionOrders",
                principalColumn: "ProductionOrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_Products_ProductId",
                table: "BatchTrackTraces",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_QualityControlLogs_QclogId",
                table: "BatchTrackTraces",
                column: "QclogId",
                principalTable: "QualityControlLogs",
                principalColumn: "Qcid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_RawMaterials_RawMaterialId",
                table: "BatchTrackTraces",
                column: "RawMaterialId",
                principalTable: "RawMaterials",
                principalColumn: "RawMaterialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_SalesOrders_SalesOrderId",
                table: "BatchTrackTraces",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "SalesOrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_ShipmentLogs_ShipmentId",
                table: "BatchTrackTraces",
                column: "ShipmentId",
                principalTable: "ShipmentLogs",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_Suppliers_SupplierId",
                table: "BatchTrackTraces",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_WarehouseInventories_WarehouseInventoryId",
                table: "BatchTrackTraces",
                column: "WarehouseInventoryId",
                principalTable: "WarehouseInventories",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillOfMaterialsBoms_Products_ProductId",
                table: "BillOfMaterialsBoms",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExciseStamps_ProductionOrders_AppliedToProductionOrderId",
                table: "ExciseStamps",
                column: "AppliedToProductionOrderId",
                principalTable: "ProductionOrders",
                principalColumn: "ProductionOrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExciseStamps_Products_ProductId",
                table: "ExciseStamps",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExciseStamps_WarehouseBins_StorageLocationBinId",
                table: "ExciseStamps",
                column: "StorageLocationBinId",
                principalTable: "WarehouseBins",
                principalColumn: "BinId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PickingPackingLists_Products_ProductId",
                table: "PickingPackingLists",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PickingPackingLists_SalesOrders_SalesOrderId",
                table: "PickingPackingLists",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "SalesOrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PickingPackingLists_WarehouseBins_BinId",
                table: "PickingPackingLists",
                column: "BinId",
                principalTable: "WarehouseBins",
                principalColumn: "BinId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrders_BillOfMaterialsBoms_Bomid",
                table: "ProductionOrders",
                column: "Bomid",
                principalTable: "BillOfMaterialsBoms",
                principalColumn: "Bomid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrders_MachineMasters_MachineId",
                table: "ProductionOrders",
                column: "MachineId",
                principalTable: "MachineMasters",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrders_Products_ProductId",
                table: "ProductionOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControlLogs_ProductionOrders_ProductionOrderId",
                table: "QualityControlLogs",
                column: "ProductionOrderId",
                principalTable: "ProductionOrders",
                principalColumn: "ProductionOrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControlLogs_Products_ProductId",
                table: "QualityControlLogs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControlLogs_RawMaterials_RawMaterialId",
                table: "QualityControlLogs",
                column: "RawMaterialId",
                principalTable: "RawMaterials",
                principalColumn: "RawMaterialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_Suppliers_PrimarySupplierId",
                table: "RawMaterials",
                column: "PrimarySupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Customers_CustomerId",
                table: "SalesOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Products_ProductId",
                table: "SalesOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentLogs_PickingPackingLists_PickPackId",
                table: "ShipmentLogs",
                column: "PickPackId",
                principalTable: "PickingPackingLists",
                principalColumn: "PickPackId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentLogs_SalesOrders_SalesOrderId",
                table: "ShipmentLogs",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "SalesOrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseInventories_Products_ProductId",
                table: "WarehouseInventories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseInventories_RawMaterials_RawMaterialId",
                table: "WarehouseInventories",
                column: "RawMaterialId",
                principalTable: "RawMaterials",
                principalColumn: "RawMaterialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseInventories_WarehouseBins_BinId",
                table: "WarehouseInventories",
                column: "BinId",
                principalTable: "WarehouseBins",
                principalColumn: "BinId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_Customers_CustomerId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_ExciseStamps_StampId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_ProductionOrders_ProductionOrderId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_Products_ProductId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_QualityControlLogs_QclogId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_RawMaterials_RawMaterialId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_SalesOrders_SalesOrderId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_ShipmentLogs_ShipmentId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_Suppliers_SupplierId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchTrackTraces_WarehouseInventories_WarehouseInventoryId",
                table: "BatchTrackTraces");

            migrationBuilder.DropForeignKey(
                name: "FK_BillOfMaterialsBoms_Products_ProductId",
                table: "BillOfMaterialsBoms");

            migrationBuilder.DropForeignKey(
                name: "FK_ExciseStamps_ProductionOrders_AppliedToProductionOrderId",
                table: "ExciseStamps");

            migrationBuilder.DropForeignKey(
                name: "FK_ExciseStamps_Products_ProductId",
                table: "ExciseStamps");

            migrationBuilder.DropForeignKey(
                name: "FK_ExciseStamps_WarehouseBins_StorageLocationBinId",
                table: "ExciseStamps");

            migrationBuilder.DropForeignKey(
                name: "FK_PickingPackingLists_Products_ProductId",
                table: "PickingPackingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_PickingPackingLists_SalesOrders_SalesOrderId",
                table: "PickingPackingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_PickingPackingLists_WarehouseBins_BinId",
                table: "PickingPackingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrders_BillOfMaterialsBoms_Bomid",
                table: "ProductionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrders_MachineMasters_MachineId",
                table: "ProductionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrders_Products_ProductId",
                table: "ProductionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityControlLogs_ProductionOrders_ProductionOrderId",
                table: "QualityControlLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityControlLogs_Products_ProductId",
                table: "QualityControlLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityControlLogs_RawMaterials_RawMaterialId",
                table: "QualityControlLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_Suppliers_PrimarySupplierId",
                table: "RawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Customers_CustomerId",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Products_ProductId",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentLogs_PickingPackingLists_PickPackId",
                table: "ShipmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentLogs_SalesOrders_SalesOrderId",
                table: "ShipmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseInventories_Products_ProductId",
                table: "WarehouseInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseInventories_RawMaterials_RawMaterialId",
                table: "WarehouseInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseInventories_WarehouseBins_BinId",
                table: "WarehouseInventories");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_Customers_CustomerId",
                table: "BatchTrackTraces",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_ExciseStamps_StampId",
                table: "BatchTrackTraces",
                column: "StampId",
                principalTable: "ExciseStamps",
                principalColumn: "StampId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_ProductionOrders_ProductionOrderId",
                table: "BatchTrackTraces",
                column: "ProductionOrderId",
                principalTable: "ProductionOrders",
                principalColumn: "ProductionOrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_Products_ProductId",
                table: "BatchTrackTraces",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_QualityControlLogs_QclogId",
                table: "BatchTrackTraces",
                column: "QclogId",
                principalTable: "QualityControlLogs",
                principalColumn: "Qcid");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_RawMaterials_RawMaterialId",
                table: "BatchTrackTraces",
                column: "RawMaterialId",
                principalTable: "RawMaterials",
                principalColumn: "RawMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_SalesOrders_SalesOrderId",
                table: "BatchTrackTraces",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_ShipmentLogs_ShipmentId",
                table: "BatchTrackTraces",
                column: "ShipmentId",
                principalTable: "ShipmentLogs",
                principalColumn: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_Suppliers_SupplierId",
                table: "BatchTrackTraces",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchTrackTraces_WarehouseInventories_WarehouseInventoryId",
                table: "BatchTrackTraces",
                column: "WarehouseInventoryId",
                principalTable: "WarehouseInventories",
                principalColumn: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillOfMaterialsBoms_Products_ProductId",
                table: "BillOfMaterialsBoms",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExciseStamps_ProductionOrders_AppliedToProductionOrderId",
                table: "ExciseStamps",
                column: "AppliedToProductionOrderId",
                principalTable: "ProductionOrders",
                principalColumn: "ProductionOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExciseStamps_Products_ProductId",
                table: "ExciseStamps",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExciseStamps_WarehouseBins_StorageLocationBinId",
                table: "ExciseStamps",
                column: "StorageLocationBinId",
                principalTable: "WarehouseBins",
                principalColumn: "BinId");

            migrationBuilder.AddForeignKey(
                name: "FK_PickingPackingLists_Products_ProductId",
                table: "PickingPackingLists",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PickingPackingLists_SalesOrders_SalesOrderId",
                table: "PickingPackingLists",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "SalesOrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PickingPackingLists_WarehouseBins_BinId",
                table: "PickingPackingLists",
                column: "BinId",
                principalTable: "WarehouseBins",
                principalColumn: "BinId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrders_BillOfMaterialsBoms_Bomid",
                table: "ProductionOrders",
                column: "Bomid",
                principalTable: "BillOfMaterialsBoms",
                principalColumn: "Bomid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrders_MachineMasters_MachineId",
                table: "ProductionOrders",
                column: "MachineId",
                principalTable: "MachineMasters",
                principalColumn: "MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrders_Products_ProductId",
                table: "ProductionOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControlLogs_ProductionOrders_ProductionOrderId",
                table: "QualityControlLogs",
                column: "ProductionOrderId",
                principalTable: "ProductionOrders",
                principalColumn: "ProductionOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControlLogs_Products_ProductId",
                table: "QualityControlLogs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControlLogs_RawMaterials_RawMaterialId",
                table: "QualityControlLogs",
                column: "RawMaterialId",
                principalTable: "RawMaterials",
                principalColumn: "RawMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_Suppliers_PrimarySupplierId",
                table: "RawMaterials",
                column: "PrimarySupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Customers_CustomerId",
                table: "SalesOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Products_ProductId",
                table: "SalesOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentLogs_PickingPackingLists_PickPackId",
                table: "ShipmentLogs",
                column: "PickPackId",
                principalTable: "PickingPackingLists",
                principalColumn: "PickPackId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentLogs_SalesOrders_SalesOrderId",
                table: "ShipmentLogs",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "SalesOrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseInventories_Products_ProductId",
                table: "WarehouseInventories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseInventories_RawMaterials_RawMaterialId",
                table: "WarehouseInventories",
                column: "RawMaterialId",
                principalTable: "RawMaterials",
                principalColumn: "RawMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseInventories_WarehouseBins_BinId",
                table: "WarehouseInventories",
                column: "BinId",
                principalTable: "WarehouseBins",
                principalColumn: "BinId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
