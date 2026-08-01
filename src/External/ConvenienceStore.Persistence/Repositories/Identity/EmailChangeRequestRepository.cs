using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.Identity;
using ConvenienceStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Repositories.Identity
{
    internal class EmailChangeRequestRepository(ConvenienceStoreDbContext context)
                : Repository<EmailChangeRequest>(context), IEmailChangeRequestRepository
    {
        private readonly ConvenienceStoreDbContext _context = context;
        public async Task<EmailChangeRequest?> FindPendingByUserIdAsync(
            int userId,
            CancellationToken cancellationToken = default)
        {
            return await _context.EmailChangeRequests
                .Where(r => r.UserId == userId && r.VerificationCode != null)
                .OrderByDescending(r => r.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<EmailChangeRequest?> FindAwaitingCurrentConfirmAsync(
            int userId,
            CancellationToken cancellationToken = default)
        {
            return await _context.EmailChangeRequests
                .Where(r => r.UserId == userId && r.VerificationCode != null && !r.CurrentEmailConfirmed)
                .OrderByDescending(r => r.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<EmailChangeRequest?> FindAwaitingNewConfirmAsync(
            int userId,
            CancellationToken cancellationToken = default)
        {
            return await _context.EmailChangeRequests
                .Where(r => r.UserId == userId && r.VerificationCode != null && r.CurrentEmailConfirmed)
                .OrderByDescending(r => r.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<EmailChangeRequest?> FindByPublicIdAsync(
            string publicId,
            CancellationToken cancellationToken = default)
        {
            return await _context.EmailChangeRequests
                .FirstOrDefaultAsync(r => r.PublicId == publicId, cancellationToken);
        }
    }
}
