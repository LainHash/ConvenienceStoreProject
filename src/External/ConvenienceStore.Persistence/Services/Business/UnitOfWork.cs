using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ConvenienceStore.Persistence.Services.Business
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ConvenienceStoreDbContext _context;

        public UnitOfWork(ConvenienceStoreDbContext context)
        {
            _context = context;
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(
            CancellationToken cancellationToken = default)
        {
            return _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
