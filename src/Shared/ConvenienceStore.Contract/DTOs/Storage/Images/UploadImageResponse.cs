using ConvenienceStore.Domain.Entities.Storage;

namespace ConvenienceStore.Contract.DTOs.Storage.Images
{
    public class UploadImageResponse
    {
        public Guid ImageId { get; set; }
        public string Url { get; set; } = string.Empty;
        public string PublicId { get; set; } = string.Empty;
        public string AltText { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public int DisplayOrder { get; set; }
        public decimal FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;
    }
}
