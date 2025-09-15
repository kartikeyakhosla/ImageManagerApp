using ImageManagerApp.DB;
using Microsoft.AspNetCore.Mvc;

namespace ImageManagerApp.Controllers
{
    public class ImageManager(ImageManagerContext imageManagerContext) : Controller
    {
        public IActionResult ManageImages(int id, string isError)
        {
            ViewBag.SelectedId = id;
            ViewBag.Error = isError;
            ViewBag.CusName = imageManagerContext.Customer.FirstOrDefault(x => x.CustomerId == id)?.CustomerName;
            ViewBag.Customers = imageManagerContext.Customer.Select(x => new { CustId = x.CustomerId, CustName = x.CustomerName }).ToList();
            return View(imageManagerContext.Image.Where(x => x.CustomerId == id).ToList());
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file, int CustId)
        {
            var countFileUploaded = imageManagerContext.Image.Where(x => x.CustomerId == CustId).Count();
            if (countFileUploaded <= 10)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    imageManagerContext.Image.Add(new Image() { CustomerId = CustId, ImageBase64 = Convert.ToBase64String(fileBytes) });
                    imageManagerContext.SaveChanges();
                }
            }
            return RedirectToAction("ManageImages", new { id = CustId, isError = countFileUploaded >= 10 ? "true" : "" });
        }
    }
}
