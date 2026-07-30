using ConvenienceStore.Domain.Enums;

namespace ConvenienceStore.Application.Extensions
{
    public static class StockStatusExtensions
    {
        public const int LowStockThreshold = 10;

        public static StockStatus ToStockStatus(this int quantityOnHand) => quantityOnHand switch
        {
            0                    => StockStatus.OutOfStock,
            < LowStockThreshold  => StockStatus.LowStock,
            _                    => StockStatus.InStock
        };
    }
}
