using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Guest;

namespace ConvenienceStore.Domain.Entities.Identity
{
    public partial class User : SoftDeletableEntity
    {
        public string UserName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

        public string? VerificationCode { get; private set; }
        public DateTime? VerificationCodeExpiresAt { get; private set; }

        public int RoleId { get; private set; }

        public Role Role { get; private set; } = null!;
        public Customer Customer { get; private set; } = null!;
    }

    public partial class User
    {
        public void SetPasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        public void SetRole(int roleId)
        {
            RoleId = roleId;
        }

        public void SetVerificationCode(string verificationCode)
        {
            VerificationCode = verificationCode;
            VerificationCodeExpiresAt = DateTime.UtcNow.AddMinutes(15);
            IsActive = false;
        }

        public void CompleteVerification()
        {
            VerificationCode = null;
            VerificationCodeExpiresAt = null;
            IsActive = true;
        }

        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
        }
    }
}
