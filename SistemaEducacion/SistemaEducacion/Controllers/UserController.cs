using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion.Models;
using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Controllers
{
    public class UserController(IUserModel _userModel, IHostEnvironment _environment, IFileModel _fileModel) : Controller
    {
        [HttpGet]
        public IActionResult BecomeProfessor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BecomeProfessor(User entity)
        {
            UserAnswer answer = new UserAnswer();

            var image = _fileModel.UploadAsync(entity.PictureUploads!).Result;

            if (image.Error)
            {
                answer.Code = "-1";
                answer.Message = "No se pudieron subir los archivos";
                return Ok(answer);
            }

            entity.PictureUrl = image.Blob.Uri;

            var resp = _userModel.BecomeProfessor(entity);
            if (resp?.Code == "00")
                return RedirectToAction("Index", "Course");
            else
            {
                ViewBag.MsjScreen = resp?.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult ViewProfessorApplicants()
        {
            var resp = _userModel.ViewProfessorApplicants();

            if (resp?.Code == "00")
            {
                return View(resp!.Data);
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Message;
                return View(new List<User>());
            }
        }

        [HttpGet]
        public IActionResult ListProfessor()
        {
            var resp = _userModel.ListProfessor();

            if (resp?.Code == "00")
            {
                return View(resp!.Data);
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Message;
                return View(new List<Course>());
            }
        }

        [HttpPost]
        public IActionResult AcceptOrRejectProfessor(User entity)
        {
            UserAnswer answer = new UserAnswer();

            var resp = _userModel.AcceptOrRejectProfessor(entity);
            if (resp?.Code == "00")
                return RedirectToAction("ViewProfessorApplicants", "User");
            else
            {
                ViewBag.MsjScreen = resp?.Message;
                return View();
            }
        }
    }
}