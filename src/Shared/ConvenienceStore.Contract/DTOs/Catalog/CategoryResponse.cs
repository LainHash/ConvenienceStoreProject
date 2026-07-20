namespace ConvenienceStore.Contract.DTOs.Catalog
{
    public class CategoryResponse
    {
        public string PublicId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
