using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.Identity;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.Identity
{
    internal class EmailChangeRequestRepository(ConvenienceStoreDbContext context)
        : Repository<EmailChangeRequest>(context), IEmailChangeRequestReqpository
    {
    }
}
