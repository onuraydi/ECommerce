using ECommerce.Images.WebUI.DAL.Entities;
using ECommerce.Images.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Images.WebUI.Controllers
{
    public class DefaultController1 : Controller
    {
        private readonly ICloudStroageService _cloudStorageService;

        public DefaultController1(ICloudStroageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ImageDrive imageDrive)
        {
            if (imageDrive.Photo != null)
            {
                imageDrive.SavedFileName = GenerateFileNameToSave(imageDrive.Photo.FileName);
                imageDrive.SavedUrl = await _cloudStorageService.UploadFileAsync(imageDrive.Photo, imageDrive.SavedFileName);
            }
            return RedirectToAction("Index", "Default");
        }

        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }
    }
}

