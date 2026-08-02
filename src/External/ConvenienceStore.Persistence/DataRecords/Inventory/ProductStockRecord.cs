namespace ConvenienceStore.Persistence.DataRecords.Inventory
{
    internal class ProductStockRecord
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int QuantityOnHand { get; set; }
        public int BranchId { get; set; }
    }
}
