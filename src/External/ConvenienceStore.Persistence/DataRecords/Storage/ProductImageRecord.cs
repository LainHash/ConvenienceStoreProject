namespace ConvenienceStore.Persistence.DataRecords.Storage
{
    internal class ProductImageRecord
    {
        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPrimary { get; set; }

        public int ProductId { get; set; }
        public int ImageId { get; set; }
    }
}
