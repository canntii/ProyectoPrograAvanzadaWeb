using Microsoft.AspNetCore.Mvc;
using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Controllers
{

    [ResponseCache(NoStore = true, Duration = 0)]
    public class CourseController(IUserModel _userModel, ICourse _courseModel, IHostEnvironment _environment, IFileModel _fileModel) : Controller
    {


        [HttpGet]
        [Route("Course/SeeLessons/{CourseID}")]
        public IActionResult SeeLessons(int CourseID)
        {
            var resp = _courseModel.SeeLessonCourse(CourseID);
            var prof = _userModel.SeeProfesorCourse(CourseID);
            string profesor = prof.Datum.FirstNameUser + " " + prof.Datum.LastNameUser;
            if (resp?.Code == "00")
            {
                ViewBag.Profesor = profesor;
                return View(resp!.Data);
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Message;
                return View(new List<Course>());
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            var resp = _courseModel.ListCourses();

            if(resp?.Code == "00")
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

            var resp = _courseModel.AddCourse(entity);
            if(resp?.Code == "00")
                return RedirectToAction("Index", "Course");
            else
            {
                ViewBag.MsjScreen = resp?.Message;
                return View();
            }
        }
    }
}
