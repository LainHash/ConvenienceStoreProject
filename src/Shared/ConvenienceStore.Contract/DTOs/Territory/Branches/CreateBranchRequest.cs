using ConvenienceStore.Domain.Enums;

namespace ConvenienceStore.Contract.DTOs.Territory.Branches
{
    public class CreateBranchRequest
    {
        public string Name { get; private set; } = null!;
        public string Code { get; private set; } = null!;

        public string PhoneNumber { get; private set; } = null!;
        public string Email { get; private set; } = null!;

        public string Address { get; private set; } = null!;

        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }

        public BranchStatus Status { get; private set; }

        public TimeOnly OpenTime { get; private set; }
        public TimeOnly CloseTime { get; private set; }
    }
}
