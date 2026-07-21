using ConvenienceStore.Contract.DTOs.Catalog.Categories;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Commands.Update
{
    public class UpdateCategorySpecification
        : BaseSpecification<Category>
    {
        public UpdateCategoryRequest Body { get; set; }
        public UpdateCategorySpecification(UpdateCategoryCommand command)
        {
            Criteria = c => string.Equals(c.PublicId, command.Id);
            Body = command.Body;
        }
    }
}
