using ConvenienceStore.Application.Enums;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.Identity.Roles.Queries.GetAll
{
    public class GetAllRolesSpecification
        : BaseSpecification<Role>
    {
        public GetAllRolesSpecification(GetAllRolesQuery query)
        {
            EnableSoftDeleteFilter();

            if (!string.IsNullOrWhiteSpace(query.Keyword))
            {
                Criteria = r =>
                    EF.Functions.Like(r.Name, $"%{query.Keyword}%") ||
                    EF.Functions.Like(r.Description, $"%{query.Keyword}%");
            }

            switch (query.SortField)
            {
                case SortField.CreatedAt:
                    if (query.Direction == SortDirection.Asc)
                        ApplyOrderBy(r => r.CreatedAt);
                    else
                        ApplyOrderByDescending(r => r.CreatedAt);
                    break;
                case SortField.Name:
                    if (query.Direction == SortDirection.Asc)
                        ApplyOrderBy(r => r.Name);
                    else
                        ApplyOrderByDescending(r => r.Name);
                    break;
            }

            ApplyPaging((query.Page - 1) * query.PageSize, query.PageSize);
        }
    }
}
