

using ConvenienceStore.Application.Enums;
using ConvenienceStore.Application.Extensions;

namespace ConvenienceStore.Application.Models
{
    public abstract record PageQuery
    {
        public string? Keyword { get; init; }
        public string SortBy { get; init; } = SortField.CreatedAt.ToSort(SortDirection.Asc);
        public int Page { get; init; } = 1;
        public int PageSize { get; init; } = 12;
    }
}
