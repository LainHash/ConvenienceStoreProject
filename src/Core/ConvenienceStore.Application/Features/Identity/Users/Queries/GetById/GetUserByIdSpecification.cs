using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Identity.Users.Queries.GetById
{
    public class GetUserByIdSpecification
        : BaseSpecification<User>
    {
        public GetUserByIdSpecification(GetUserByIdQuery query)
        {
            Criteria = u => string.Equals(u.PublicId, query.Id);
            AddInclude(x => x.Role);
        }
    }
}
