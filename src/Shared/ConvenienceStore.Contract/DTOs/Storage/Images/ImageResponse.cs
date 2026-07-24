namespace ConvenienceStore.Contract.DTOs.Storage.Images
{
    public class ImageResponse
    {
        public string Id { get; set; } = string.Empty;

        public string AltText { get; private set; } = null!;

        public string Url { get; private set; } = null!;

        public int DisplayOrder { get; private set; }
    }
}
