namespace ConvenienceStore.Persistence.DataRecords.Catalog
{
    internal class ProductRecord
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
