namespace ConvenienceStore.Contract.DTOs.Catalog
{
    public class BrandResponse
    {
        public string PublicId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
