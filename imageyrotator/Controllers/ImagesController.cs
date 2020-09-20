using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageYRotator
{
    [Route("api/images")]
    public class ImagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var pathToFile = Path.GetFullPath(Directory.GetCurrentDirectory()) + "\\tux-327x360.png";

            Bitmap image = (Bitmap)Bitmap.FromFile(pathToFile);

            return File(Rotate180FlipY(image), "image/png");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            using var memoryStream = new MemoryStream();

            await file.CopyToAsync(memoryStream);

            Bitmap image = (Bitmap)Bitmap.FromStream(memoryStream);

            return File(Rotate180FlipY(image), "image/png");
        }

        private static byte[] Rotate180FlipY(Bitmap image)
        {
            image.RotateFlip(RotateFlipType.Rotate180FlipY);

            using var stream = new MemoryStream();

            image.Save(stream, ImageFormat.Png);

            return stream.ToArray();
        }
    }
}