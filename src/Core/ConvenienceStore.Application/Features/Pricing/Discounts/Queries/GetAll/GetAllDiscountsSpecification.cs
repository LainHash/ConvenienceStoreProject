using ConvenienceStore.Domain.Entities.Pricing;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetAll
{
    public class GetAllDiscountsSpecification
        : BaseSpecification<Discount>
    {
        public GetAllDiscountsSpecification(GetAllDiscountsQuery query)
        {

        }
    }
}
