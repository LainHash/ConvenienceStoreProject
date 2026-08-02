using ConvenienceStore.Contract.DTOs.Storage.Images;
using ConvenienceStore.Domain.Enums;

namespace ConvenienceStore.Contract.DTOs.Catalog.Products
{
    public class ProductResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string CategoryName { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;

        public IEnumerable<ImageResponse> Images { get; set; } = [];
        public ImageResponse? PrimaryImage { get; set; }
    }
}
