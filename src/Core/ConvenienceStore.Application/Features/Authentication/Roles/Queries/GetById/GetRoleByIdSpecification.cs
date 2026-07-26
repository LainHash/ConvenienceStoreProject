using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Authentication.Roles.Queries.GetById
{
    public class GetRoleByIdSpecification
        : BaseSpecification<Role>
    {
        public GetRoleByIdSpecification(GetRoleByIdQuery query)
        {
            Criteria = r => string.Equals(r.PublicId, query.Id);

            EnableSoftDeleteFilter();
        }
    }
}
