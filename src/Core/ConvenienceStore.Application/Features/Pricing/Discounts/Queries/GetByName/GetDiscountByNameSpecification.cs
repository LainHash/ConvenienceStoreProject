using ConvenienceStore.Domain.Entities.Pricing;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetByName
{
    public class GetDiscountByNameSpecification
        : BaseSpecification<Discount>
    {
        public GetDiscountByNameSpecification(GetDiscountByNameQuery query)
        {
            Criteria = d => string.Equals(d.Name, query.Name);
        }
    }
}
