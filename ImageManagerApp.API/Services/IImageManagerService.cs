using ImageManagerApp.DB;

namespace ImageManagerApp.API.Services
{
    public interface IImageManagerService
    {
        bool SaveImage(Image image);
        List<Image> GetAllImagesByCustomerId(int customerId);
        void DeleteImageById(int imageId);
    }
}
