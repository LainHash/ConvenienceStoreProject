using ConvenienceStore.Application.Enums;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Domain.Specifications;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.Catalog.Products.Queries.GetAll
{
    public class GetAllProductSpecification
        : BaseSpecification<Product>
    {
        public GetAllProductSpecification(GetAllProductQuery query)
        {
            AddInclude(x => x.ProductStock);
            AddInclude(x => x.ProductPrice);
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
            AddIncludeAggregator(x => x.Include(p => p.ProductImages)
                                        .ThenInclude((ProductImage pi) => pi.Image));

            EnableSoftDeleteFilter();

            if (!string.IsNullOrWhiteSpace(query.Keyword))
            {
                Criteria = p =>
                    EF.Functions.Like(p.Name, $"%{query.Keyword}%") ||
                    EF.Functions.Like(p.Description, $"%{query.Keyword}%") ||
                    EF.Functions.Like(p.Category.Name, $"%{query.Keyword}%") ||
                    EF.Functions.Like(p.Brand.Name, $"%{query.Keyword}%");
            }

            if (!string.IsNullOrWhiteSpace(query.CategoryName))
            {
                Criteria = p => EF.Functions.Like(p.Category.Name, $"%{query.CategoryName}%");
            }

            if (!string.IsNullOrWhiteSpace(query.BrandName))
            {
                Criteria = p => EF.Functions.Like(p.Brand.Name, $"%{query.BrandName}%");
            }

            switch (query.SortField)
            {
                case SortField.CreatedAt:
                    if (query.Direction == SortDirection.Asc)
                        ApplyOrderBy(p => p.CreatedAt);
                    else
                        ApplyOrderByDescending(p => p.CreatedAt);
                    break;
                case SortField.Name:
                    if (query.Direction == SortDirection.Asc)
                        ApplyOrderBy(p => p.Name);
                    else
                        ApplyOrderByDescending(p => p.Name);
                    break;
                case SortField.Price:
                    if (query.Direction == SortDirection.Asc)
                        ApplyOrderBy(p => p.ProductPrice.UnitPrice);
                    else
                        ApplyOrderByDescending(p => p.ProductPrice.UnitPrice);
                    break;
            }

            ApplyPaging((query.Page - 1) * query.PageSize, query.PageSize);
        }
    }
}
