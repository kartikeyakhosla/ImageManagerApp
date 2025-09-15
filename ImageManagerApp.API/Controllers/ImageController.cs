using ImageManagerApp.API.Models;
using ImageManagerApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImageManagerApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageManagerService _imageManagerService;
        public ImageController(IImageManagerService imageManagerService)
        {
            _imageManagerService = imageManagerService;
        }

        [HttpPost]
        public IActionResult Post(Image image)
        {
            var ret = _imageManagerService
                .SaveImage(new DB.Image() { CustomerId = image.CustomerId, ImageBase64 = image.ImageBase64 });
            if (ret == true)
                return Ok(ret);
            else
                return BadRequest("Customer already has 10 images uploaded, Can't add more!");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_imageManagerService
                .GetAllImagesByCustomerId(id));
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete([FromRoute] int id)
        {
            _imageManagerService
                .DeleteImageById(id);
        }
    }
}
