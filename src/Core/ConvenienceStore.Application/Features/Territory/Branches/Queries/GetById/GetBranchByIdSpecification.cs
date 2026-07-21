using ConvenienceStore.Domain.Entities.Territory;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Territory.Branches.Queries.GetById
{
    public class GetBranchByIdSpecification
        : BaseSpecification<Branch>
    {
        public GetBranchByIdSpecification(GetBranchByIdQuery query)
        {
            Criteria = x => string.Equals(x.PublicId, query.Id);
            EnableSoftDeleteFilter();
        }
    }
}
