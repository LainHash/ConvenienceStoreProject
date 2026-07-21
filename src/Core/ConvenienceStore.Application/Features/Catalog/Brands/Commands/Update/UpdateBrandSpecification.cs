using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Commands.Update
{
    public class UpdateBrandSpecification
        : BaseSpecification<Brand>
    {
        public Contract.DTOs.Catalog.UpdateBrandRequest Body { get; }

        public UpdateBrandSpecification(UpdateBrandCommand command)
        {
            Criteria = x => string.Equals(x.PublicId, command.Id);
            Body = command.Body;
        }
    }
}
