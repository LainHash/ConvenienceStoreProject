using ConvenienceStore.Domain.Entities.Pricing;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetById
{
    public class GetDiscountByIdSpecification
        : BaseSpecification<Discount>
    {
        public GetDiscountByIdSpecification(GetDiscountByIdQuery query)
        {
            Criteria = d => string.Equals(d.PublicId, query.Id);
        }
    }
}
