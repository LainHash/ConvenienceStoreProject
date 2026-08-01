namespace ConvenienceStore.Contract.DTOs.Financial
{
    public class WalletResponse
    {
        public string Id { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public bool IsLocked { get; set; }
    }
}
