using Filmsammlung.Data;
using Filmsammlung.Model;
using Filmsammlung.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace FilmSammlung_MVC.Controllers
{
    [Route("View")]
    public class ViewController : Controller
    {
        private IImageService imageService;
        public ViewController(IImageService imageService)
        {
            this.imageService = imageService;
        }
       
        [HttpGet]
        public IActionResult ImageUploader()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult UploadImage()
        {
            foreach (var file in Request.Form.Files)
            {
                DbImage img = new DbImage();
                img.Name = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.imageData = ms.ToArray();

                ms.Close();
                ms.Dispose();

                imageService.AddImage(img);
            }
            
            ViewBag.Message = "Image(s) stored in database!";
            return View("ImageUploader");
        }
        [HttpPost("GetImages")]
        public ActionResult RetrieveImage()
        {
            DbImage img = imageService.GetImageById(1);
            string imageBase64Data =
        Convert.ToBase64String(img.imageData);
            string imageDataURL =
        string.Format("data:image/jpg;base64,{0}",
        imageBase64Data);
            ViewBag.ImageTitle = img.Name;
            ViewBag.ImageDataUrl = imageDataURL;
            return View("ImageUploader");
        }
    }
}
