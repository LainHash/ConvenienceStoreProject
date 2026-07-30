using ConvenienceStore.Domain.Abstraction;

namespace ConvenienceStore.Domain.Entities.Identity
{
    public class EmailChangeRequest : AuditableEntity
    {
        public int UserId { get; private set; }

        public string NewEmail { get; private set; } = string.Empty;

        public string? VerificationCode { get; private set; }
        public DateTime? VerificationCodeExpiresAt { get; private set; }

        public User User { get; private set; } = null!;
    }
}
