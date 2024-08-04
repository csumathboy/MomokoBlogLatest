using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;
using MomokoBlog.Web.Models;
using MomokoBlog.BlobFile;

namespace MomokoBlog.Web.Controllers
{
    public class FilesController : Controller
    {
        private readonly IFileAppService _fileAppService;

        public FilesController(IFileAppService fileAppService)
        {
            _fileAppService = fileAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> UploadImage([FromForm] IFormFile upload)
        {
            if (upload.Length <= 0) return new JsonResult("");

            //your custom code logic here

            //1)check if the file is image

            //2)check if the file is too large

            //etc

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

            //save file to Blob


            var filePath = "/uploadfiles/" + fileName;

            using (var memoryStream = new MemoryStream())
            {
                await upload.CopyToAsync(memoryStream);

                await _fileAppService.SaveBlobAsync(
                    new SaveBlobInputDto
                    {
                        Name = fileName,
                        Content = memoryStream.ToArray()
                    }
                );
            }
        

            var url = filePath;

            var success = new UploadSuccess
            {
                Uploaded = 1,
                FileName = fileName,
                Url = url
            };

            return new JsonResult(success);
        }

 
    }
}
