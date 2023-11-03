using Microsoft.AspNetCore.Mvc;
using WebBanDienThoai.Services;

namespace WebBanDienThoai.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : BaseController
    {
        private readonly ImageServices _imageServices;

        public ImageController(ImageServices imageServices)
        {
            _imageServices = imageServices;
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetImage(string name)
        {
            var stream = await _imageServices.GetImageAsync(name);
            return File(stream, "image/png");
        }
    }
}
