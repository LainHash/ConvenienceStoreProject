using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Financial.Wallets.Queries.GetByUserId
{
    public class GetWalletByUserIdSpecification
        : BaseSpecification<Wallet>
    {
        public string UserId { get; set; }
        public GetWalletByUserIdSpecification(GetWalletByUserIdQuery query)
        {
            AddInclude(x => x.Customer);

            UserId = query.UserId;
        }
    }
}
