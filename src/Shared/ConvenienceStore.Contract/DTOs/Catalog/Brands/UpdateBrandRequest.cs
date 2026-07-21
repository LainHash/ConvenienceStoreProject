namespace ConvenienceStore.Contract.DTOs.Catalog
{
    public class UpdateBrandRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
