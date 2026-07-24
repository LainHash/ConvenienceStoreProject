using ConvenienceStore.Domain.Abstraction;

namespace ConvenienceStore.Domain.Entities.Storage
{
    public partial class Image : AuditableEntity
    {
        public string AltText { get; private set; } = null!;

        public string Url { get; private set; } = null!;
        public string StoragePath { get; private set; } = null!;

        public decimal FileSize { get; private set; }
        public string ContentType { get; private set; } = null!;

        public ProductImage ProductImage { get; private set; } = null!;
    }
}
