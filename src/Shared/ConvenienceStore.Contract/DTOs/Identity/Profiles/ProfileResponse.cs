namespace ConvenienceStore.Contract.DTOs.Identity.Profiles
{
    public class ProfileResponse
    {
        public string Id { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateOnly Dob { get; set; }
        public bool Gender { get; set; }

        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string CitizenCardId { get; set; } = string.Empty;
    }
}
