 using Microsoft.AspNetCore.Mvc;
using SistemaEducacion.WebEntities;
using SistemaEducacion.Models;
using SistemaEducacion.Services;
using Microsoft.AspNetCore.Authorization;

namespace SistemaEducacion.Controllers
{

    [ResponseCache(NoStore = true, Duration = 0)]
    public class HomeController(IUserModel _userModel, IUtilitariosModel _utilitariosModel) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]  
        public IActionResult Login(User entity) 
        {
            entity.PasswordUser = _utilitariosModel.Encrypt(entity.PasswordUser!);
            var resp = _userModel.Login(entity);

            if (resp?.Code == "00")
            {
                HttpContext.Session.SetString("EmailUser", resp?.Datum?.EmailUser!);
                HttpContext.Session.SetString("FirstNameUser", resp?.Datum?.FirstNameUser!);
                HttpContext.Session.SetString("RoleId", resp?.Datum?.RoleID!.ToString());
                HttpContext.Session.SetString("UserId", resp?.Datum?.UserId!.ToString());
                HttpContext.Session.SetString("Token", resp?.Datum?.Token!);

                if ((bool)(resp?.Datum?.Temporary!))
                    return RedirectToAction("ChangePassword", "Home");
                else
                {
                    HttpContext.Session.SetString("Login", "true");
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.MsjScreen = resp?.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(User entity)
        {
            entity.PasswordUser = _utilitariosModel.Encrypt(entity.PasswordUser!);
            var resp = _userModel.RegisterUser(entity);

            if (resp?.Code == "00")
                return RedirectToAction("Login", "Home");
            else
            {
                ViewBag.MsjScreen = resp?.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult RecoverAccess()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult RecoverAccess(User entity)
        {
            var resp = _userModel.RecoverAccess(entity);

            if (resp?.Code == "00")
                return RedirectToAction("Login", "Home");
            else
            {
                ViewBag.MsjScreen = resp?.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            var user = new User();
            user.EmailUser = HttpContext.Session.GetString("EmailUser");

            return View(user);
        }

        [HttpPost]
        public IActionResult ChangePassword(User entity)
        {
            if(entity.PasswordUser?.Trim() == entity.TemporalPassword?.Trim())
            {
                ViewBag.MsjScreen = "Debe de utilizar una clave distinta";
                return View();

            }
            entity.PasswordUser = _utilitariosModel.Encrypt(entity.PasswordUser!);
            entity.TemporalPassword = _utilitariosModel.Encrypt(entity.TemporalPassword!);

            var resp = _userModel.ChangePassword(entity);

            if (resp?.Code == "00")
            {
                HttpContext.Session.SetString("Login", "true");
                return RedirectToAction("Index", "Home");
            }
               
            else
            {
                ViewBag.MsjScreen = resp?.Message;
                return View();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Security]
        [HttpGet]
        public IActionResult Salir()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

    }
}
