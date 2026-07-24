using ConvenienceStore.Domain.Abstraction;

namespace ConvenienceStore.Domain.Entities.Identity
{
    public class User : SoftDeletableEntity
    {
        public string UserName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

        public string? VerificationCode { get; private set; }
        public DateTime? VerificationCodeExpiresAt { get; private set; }

        public int RoleId { get; private set; }

        public Role Role { get; private set; } = null!;
    }
}
