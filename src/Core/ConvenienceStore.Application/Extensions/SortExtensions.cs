using ConvenienceStore.Application.Enums;

namespace ConvenienceStore.Application.Extensions
{
    public static class SortExtensions
    {
        public static string ToSort(this SortField field, SortDirection direction)
        {
            return $"{ToSnakeCase(field)}_{direction.ToString().ToLower()}";
        }

        private static string ToSnakeCase(SortField field)
        {
            switch (field)
            {
                case SortField.CreatedAt: 
                    return "created_at";
                case SortField.Name:
                    return "name";
                case SortField.Price:
                    return "price";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
