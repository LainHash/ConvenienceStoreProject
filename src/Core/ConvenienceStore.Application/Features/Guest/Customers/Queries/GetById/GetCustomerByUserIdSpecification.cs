using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.Guest.Customers.Queries.GetById
{
    public class GetCustomerByUserIdSpecification
        : BaseSpecification<Customer>
    {
        public GetCustomerByUserIdSpecification(GetCustomerByUserIdQuery query)
        {
            AddInclude(x => x.Profile!);
            AddIncludeAggregator(x => x.Include(c => c.User)
                                        .ThenInclude((User u) => u.Role));
            Criteria = c => string.Equals(c.User.PublicId, query.UserId);
        }
    }
}
