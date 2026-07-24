namespace ConvenienceStore.Persistence.DataRecords.Storage
{
    internal class ImageRecord
    {
        public int Id { get; set; }
        public string AltText { get; set; } = null!;

        public string Url { get; set; } = null!;
        public string StoragePath { get; set; } = null!;

        public decimal FileSize { get; set; }
        public string ContentType { get; set; } = null!;
    }
}
