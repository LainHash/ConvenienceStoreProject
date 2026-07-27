using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.Guest.Customers.Queries.GetAll
{
    public class GetAllCustomersSpecification
        : BaseSpecification<Customer>
    {
        public GetAllCustomersSpecification(GetAllCustomersQuery query)
        {
            AddInclude(x => x.Profile!);
            AddIncludeAggregator(x => x.Include(c => c.User)
                                        .ThenInclude((User u) => u.Role));
        }
    }
}
