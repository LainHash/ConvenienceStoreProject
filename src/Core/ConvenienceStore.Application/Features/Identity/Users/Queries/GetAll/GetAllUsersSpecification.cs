using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Identity.Users.Queries.GetAll
{
    public class GetAllUsersSpecification
        : BaseSpecification<User>
    {
        public GetAllUsersSpecification(GetAllUsersQuery query)
        {
            AddInclude(x => x.Role);
        }
    }
}
