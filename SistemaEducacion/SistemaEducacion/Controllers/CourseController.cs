using Microsoft.AspNetCore.Mvc;
using SistemaEducacion.Models;
using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;
using System.Security.Permissions;

namespace SistemaEducacion.Controllers
{

    [ResponseCache(NoStore = true, Duration = 0)]
    public class CourseController(IVideoModel _videoModel, ILesson _lessonModel, IUserModel _userModel, ICourse _courseModel, IHostEnvironment _environment, IFileModel _fileModel, IConfiguration _config) : Controller
    {
        [HttpGet]
        [Route("Course/SeeLessons/{CourseID}")]
        public IActionResult SeeLessons(int CourseID)
        {
            var resp = _courseModel.SeeLessonCourse(CourseID);
            var prof = _userModel.SeeProfesorCourse(CourseID);

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

        [HttpGet]
        [Route("Course/SeeContentLesson/{LessonID}")]
        public IActionResult SeeContentLesson(int LessonID)
        {
            var resp = _lessonModel.SeeContentLesson(LessonID);

            if (resp?.Code == "00")
            {
                return View(resp!.Datum);
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Message;
                return View(new List<Lesson>());
            }
        }

        [HttpGet]
        [Route("Course/RegisterLesson/{CourseID}")]
        public IActionResult RegisterLesson()
        {
            return View();
        }

        [HttpPost]
        [Route("Course/RegisterLesson/{CourseID}")]
        public IActionResult RegisterLesson(Lesson entity, int CourseID)
        {

            //Agregar la clase
            var respLesson = _lessonModel.AddLesson(entity);

            //Consultar el ultimo ingresado
            var respCourse = _lessonModel.LastInsert(CourseID);
            
           

            //Si la clase se agrega
            if (respLesson?.Code == "1" && respCourse?.Code != null)
            {
                var LessonID = respCourse?.Datum?.LessonID;

                return RedirectToAction("UploadVideo", "Video", new { LessonID });
            }
            else
            {
                ViewBag.MsjScreen = respLesson?.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            var resp = _courseModel.ListCourses();

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

        [HttpGet]
        public IActionResult MyCourses()
        {
            var login = Convert.ToBoolean(HttpContext.Session.GetString("Login"));
            if (login == null || login == false)
            {
                return RedirectToAction("Login", "Home");
            }

            var roles = _config.GetSection("roles");
            var RoleId = HttpContext.Session.GetString("RoleId");
            var UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            if (RoleId == roles["Professor"])
            {
                var misCursos = _courseModel.ListMyCourses(UserId);

                if (misCursos?.Code == "00")
                {
                    ViewBag.Miscursos = misCursos!.Data;
                }
            }
            var resp = _courseModel.ListMySucriptionCourses(UserId);

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

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult? AddCourse(Course entity)
        {
            CourseAnswer answer = new CourseAnswer();

            var image = _fileModel.UploadAsync(entity.PictureUploads!).Result;

            if (image.Error)
            {
                answer.Code = "-1";
                answer.Message = "No se pudieron subir los archivos";
                return Ok(answer);
            }

            entity.PictureUrl = image.Blob.Uri;
            entity.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var resp = _courseModel.AddCourse(entity);
            if (resp?.Code == "1")
                return RedirectToAction("MyCourses", "Course");
            else
            {
                ViewBag.MsjScreen = resp?.Message;
                return View();
            }
        }
    }
}
