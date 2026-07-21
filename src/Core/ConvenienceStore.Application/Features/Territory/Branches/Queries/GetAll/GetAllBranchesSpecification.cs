using ConvenienceStore.Domain.Entities.Territory;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Territory.Branches.Queries.GetAll
{
    public class GetAllBranchesSpecification
        : BaseSpecification<Branch>
    {
        public GetAllBranchesSpecification(GetAllBranchesQuery query)
        {
            EnableSoftDeleteFilter();
        }
    }
}
