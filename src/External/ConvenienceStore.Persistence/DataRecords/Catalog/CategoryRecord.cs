namespace ConvenienceStore.Persistence.DataRecords.Catalog
{
    internal class CategoryRecord
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
