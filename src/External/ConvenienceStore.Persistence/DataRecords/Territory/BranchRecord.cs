namespace ConvenienceStore.Persistence.DataRecords.Territory
{
    public class BranchRecord
    {
        public int Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
