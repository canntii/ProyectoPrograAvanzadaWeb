using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion.Models;
using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Controllers
{
    public class UserController(IUserModel _userModel, IHostEnvironment _environment, IFileModel _fileModel, IUtilitariosModel _utilitariosModel) : Controller
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
            if (resp?.Code == "0")
                return RedirectToAction("MyAccount", "User");
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

        [HttpGet]
        public IActionResult MyAccount()
        {
            var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            ViewBag.id = id;
            var resp = _userModel.SearchUser(id);
            return View(resp.Datum);
        }

        [HttpPost]
        public IActionResult Login(string EmailUser, string PasswordUser)
        {
            var entity = new User
            {
                EmailUser = EmailUser,
                PasswordUser = PasswordUser
            };

            entity.PasswordUser = _utilitariosModel.Encrypt(entity.PasswordUser!);
            var resp = _userModel.Login(entity);

            return Json(resp);

        }

        [HttpGet]
        public IActionResult UpdateUser()
        {
            var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var resp = _userModel.SearchUser(id);
            resp.Datum.PasswordUser = _utilitariosModel.Decrypt(resp.Datum.PasswordUser!);
            return View(resp.Datum);
        }

        [HttpPost]
        public IActionResult UpdateUser(User entity)
        {
            var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            entity.UserId = id;
            entity.PasswordUser = _utilitariosModel.Encrypt(entity.PasswordUser!);
            var resp = _userModel.UpdateUser(entity);

            if (resp?.Code == "00")
                return RedirectToAction("MyAccount", "User");
            else
            {
                ViewBag.MsjScreen = resp?.Message;
                return View();
            }
        }

    }
}