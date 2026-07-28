using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.Guest.Customers.Queries.GetById
{
    public class GetCustomerByIdSpecification
        : BaseSpecification<Customer>
    {
        public GetCustomerByIdSpecification(GetCustomerByIdQuery query)
        {
            AddInclude(x => x.Profile!);
            AddIncludeAggregator(x => x.Include(c => c.User)
                                        .ThenInclude((User u) => u.Role));
            Criteria = c => string.Equals(c.PublicId, query.Id);
        }
    }
}
