using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaEducacion.Models;
using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;
using System.Data;
using System.IO;

namespace SistemaEducacion.Controllers
{
    [ResponseCache(NoStore = true, Duration = 0)]
    public class VideoController(IFileModel _fileModel, IVideoModel _videoModel) : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpGet]
        public IActionResult UploadVideo()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult UploadVideo(Video entity)
        {
            //PENDIENTE HACER UN TRY CATCH PARA CUANDO YA EL VIDEO EXISTE EN LA NUBE
            
            VideoAnswer answer = new VideoAnswer();

            var photoResult = _fileModel.UploadAsync(entity.MiniPictureUploads!).Result;
            var videoResult = _fileModel.UploadAsync(entity.VideoUploads!).Result;

            if (photoResult.Error || videoResult.Error)
            {
                answer.Code = "-1";
                answer.Message = "No se pudieron subir los archivos";
                return Ok(answer);
            }

            entity.MiniPictureUrl = photoResult.Blob.Uri;
            entity.VideoUrl = videoResult.Blob.Uri;

            var resp = _videoModel.UploadVideo(entity);

            if (resp?.Code == "00")
                return RedirectToAction("Login", "Home");
            else
            {
                ViewBag.MsjScreen = resp?.Message;
                return View();
            }

        }
    }
}
