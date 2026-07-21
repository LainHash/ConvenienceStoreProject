namespace ConvenienceStore.Contract.DTOs.Catalog.Categories
{
    public class UpdateCategoryRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
