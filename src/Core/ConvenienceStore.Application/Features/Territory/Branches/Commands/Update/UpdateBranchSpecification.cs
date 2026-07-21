using ConvenienceStore.Domain.Entities.Territory;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Territory.Branches.Commands.Update
{
    public class UpdateBranchSpecification
        : BaseSpecification<Branch>
    {
        public Contract.DTOs.Territory.UpdateBranchRequest Body { get; }

        public UpdateBranchSpecification(UpdateBranchCommand command)
        {
            Criteria = x => string.Equals(x.PublicId, command.Id);
            Body = command.Body;
        }
    }
}
