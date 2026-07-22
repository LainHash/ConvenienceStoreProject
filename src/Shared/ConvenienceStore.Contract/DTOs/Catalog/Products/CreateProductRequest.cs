namespace ConvenienceStore.Contract.DTOs.Catalog.Products
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public decimal UnitPrice { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int QuantityOnHand { get; set; } = 0;

        public string CategoryId { get; set; } = string.Empty;
        public string BrandId { get; set; } = string.Empty;
    }
}
