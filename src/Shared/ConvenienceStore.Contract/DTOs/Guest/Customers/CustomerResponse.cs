using ConvenienceStore.Contract.DTOs.Identity.Profiles;
using ConvenienceStore.Contract.DTOs.Identity.Users;

namespace ConvenienceStore.Contract.DTOs.Guest.Customers
{
    public class CustomerResponse
    {
        public string Id { get; set; } = string.Empty;

        public UserResponse User { get; set; } = null!;
        public ProfileResponse Profile { get; set; } = null!;
    }
}
