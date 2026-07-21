using ConvenienceStore.Domain.Entities.Territory;

namespace ConvenienceStore.Domain.Repositories.Territory
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task<Branch?> FindAsync(string id, CancellationToken cancellationToken = default);
    }
}
