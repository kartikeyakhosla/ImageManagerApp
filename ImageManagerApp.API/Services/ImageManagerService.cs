using ImageManagerApp.DB;
using Microsoft.EntityFrameworkCore;

namespace ImageManagerApp.API.Services
{
    public class ImageManagerService(ImageManagerContext imageManagerContext) : IImageManagerService
    {
        public void DeleteImageById(int imageId)
        {
            var image = imageManagerContext.Image.FirstOrDefault(x => x.ImageId == imageId);
            if (image != null)
            {
                imageManagerContext.Image.Remove(image);
                imageManagerContext.SaveChanges();
            }
        }

        public List<Image> GetAllImagesByCustomerId(int customerId)
        {
            return imageManagerContext.Image.Where(x => x.CustomerId == customerId).ToList();
        }

        public bool SaveImage(Image image)
        {
            var countAlreadySavedImages = imageManagerContext.Image.Where(x => x.CustomerId == image.CustomerId).Count();
            if (countAlreadySavedImages >= 10) return false;
            else
            {
                imageManagerContext.Image.Add(image);
                imageManagerContext.SaveChanges();
                return true;
            }
        }
    }
}
