using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetAll
{
    public class GetAllBrandsSpecification
        : BaseSpecification<Brand>
    {
        public GetAllBrandsSpecification(GetAllBrandsQuery query)
        {
            EnableSoftDeleteFilter();
        }
    }
}
