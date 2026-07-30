using ConvenienceStore.Domain.Abstraction;

namespace ConvenienceStore.Domain.Entities.Identity
{
    public class EmailChangeRequest : AuditableEntity
    {
        public int UserId { get; private set; }

        public string NewEmail { get; private set; } = string.Empty;

        public string? VerificationCode { get; private set; }
        public DateTime? VerificationCodeExpiresAt { get; private set; }

        /// <summary>
        /// Trạng thái xác nhận từ email hiện tại (bước 2).
        /// false = đang chờ xác nhận current email.
        /// true  = đã xác nhận current email, đang chờ xác nhận email mới.
        /// </summary>
        public bool CurrentEmailConfirmed { get; private set; }

        public User User { get; private set; } = null!;

        // ── Factory ──────────────────────────────────────────────────────────

        public static EmailChangeRequest Create(int userId, string newEmail)
        {
            return new EmailChangeRequest
            {
                UserId = userId,
                NewEmail = newEmail,
                CurrentEmailConfirmed = false
            };
        }

        // ── Domain Methods ────────────────────────────────────────────────────

        /// <summary>
        /// Gán mã OTP và đặt thời hạn 15 phút.
        /// </summary>
        public void SetVerificationCode(string verificationCode)
        {
            VerificationCode = verificationCode;
            VerificationCodeExpiresAt = DateTime.UtcNow.AddMinutes(15);
        }

        /// <summary>
        /// Đánh dấu current email đã xác nhận thành công.
        /// Xóa OTP cũ để chuẩn bị ghi OTP mới cho email mới.
        /// </summary>
        public void ConfirmCurrentEmail()
        {
            CurrentEmailConfirmed = true;
            VerificationCode = null;
            VerificationCodeExpiresAt = null;
        }

        /// <summary>
        /// Kiểm tra OTP đã hết hạn chưa.
        /// </summary>
        public bool IsExpired()
            => VerificationCodeExpiresAt is null || DateTime.UtcNow > VerificationCodeExpiresAt;

        /// <summary>
        /// Kiểm tra OTP hợp lệ (khớp mã và chưa hết hạn).
        /// </summary>
        public bool IsCodeValid(string code)
            => !IsExpired() && string.Equals(VerificationCode, code, StringComparison.Ordinal);
    }
}

