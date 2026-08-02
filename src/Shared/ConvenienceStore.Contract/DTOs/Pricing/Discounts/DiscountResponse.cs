using ConvenienceStore.Domain.Enums;

namespace ConvenienceStore.Contract.DTOs.Pricing.Discounts
{
    public class DiscountResponse
    {
        public string Id { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;

        public DiscountType Type { get; private set; }
        public decimal Value { get; private set; }
        public decimal? MaximumDiscountAmount { get; private set; }
        public decimal? MinimumOrderAmount { get; private set; }

        public DateTime StartAt { get; private set; }
        public DateTime EndAt { get; private set; }
        public bool IsActive { get; private set; }
    }
}
