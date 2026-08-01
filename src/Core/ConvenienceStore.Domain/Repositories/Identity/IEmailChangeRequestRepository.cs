using ConvenienceStore.Domain.Entities.Identity;

namespace ConvenienceStore.Domain.Repositories.Identity
{
    public interface IEmailChangeRequestRepository : IRepository<EmailChangeRequest>
    {
        /// <summary>
        /// Tìm request bất kỳ đang pending của user (dùng để hủy khi tạo request mới).
        /// </summary>
        Task<EmailChangeRequest?> FindPendingByUserIdAsync(int userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Bước 2: Tìm request đang chờ xác nhận từ current email (CurrentEmailConfirmed = false).
        /// </summary>
        Task<EmailChangeRequest?> FindAwaitingCurrentConfirmAsync(int userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Bước 3: Tìm request đã xác nhận current email, đang chờ xác nhận email mới (CurrentEmailConfirmed = true).
        /// </summary>
        Task<EmailChangeRequest?> FindAwaitingNewConfirmAsync(int userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tìm request theo PublicId (GUID string).
        /// </summary>
        Task<EmailChangeRequest?> FindByPublicIdAsync(string publicId, CancellationToken cancellationToken = default);
    }
}
