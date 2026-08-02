namespace ConvenienceStore.Persistence.DataRecords.Inventory
{
    internal class ProductPriceRecord
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
    }
}
