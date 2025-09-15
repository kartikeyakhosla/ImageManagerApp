namespace ImageManagerApp.API.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageBase64 { get; set; } = string.Empty;
        public int CustomerId { get; set; }
    }
}
