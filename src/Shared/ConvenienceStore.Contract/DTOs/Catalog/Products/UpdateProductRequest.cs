namespace ConvenienceStore.Contract.DTOs.Catalog.Products
{
    public class UpdateProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public decimal UnitPrice { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int QuantityOnHand { get; set; }

        public string CategoryId { get; set; } = string.Empty;
        public string BrandId { get; set; } = string.Empty;
    }
}
