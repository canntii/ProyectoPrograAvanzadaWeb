using Microsoft.AspNetCore.Mvc;
using SistemaEducacion.Models;
using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;
using System.Security.Permissions;

namespace SistemaEducacion.Controllers
{

    [ResponseCache(NoStore = true, Duration = 0)]
    public class CourseController(IVideoModel _videoModel, ILesson _lessonModel, IUserModel _userModel, ICourse _courseModel, IHostEnvironment _environment, IFileModel _fileModel) : Controller
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
        [Route("Course/RegisterLesson/{CourseID}")]
        public IActionResult RegisterLesson()
        {
            return View();
        }

        [HttpPost]
        [Route("Course/RegisterLesson/{CourseID}")]
        public IActionResult RegisterLesson(Lesson entity, Video video)
        {
            VideoAnswer videoAnswer = new VideoAnswer();

            var photoResult = _fileModel.UploadAsync(video.MiniPictureUploads!).Result;
            var videoResult = _fileModel.UploadAsync(video.VideoUploads!).Result;

            if (photoResult.Error || videoResult.Error)
            {
                videoAnswer.Code = "-1";
                videoAnswer.Message = "No se pudieron subir los archivos";
                return Ok(videoAnswer);
            }

            video.MiniPictureUrl = photoResult.Blob.Uri;
            video.VideoUrl = videoResult.Blob.Uri;

            var respVideo = _videoModel.UploadVideo(video);
            var respLesson = _lessonModel.AddLesson(entity);

            if (respVideo?.Code == "00" && respLesson?.Code == "00")
                return RedirectToAction("Index", "Course");
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
        public IActionResult MyCourses()
        {
            var roles = _config.GetSection("roles");
            var RoleId = HttpContext.Session.GetString("RoleId");
            var UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            if(RoleId == roles["Professor"])
            {
                var misCursos = _courseModel.ListMyCourses(UserId);

                if(misCursos?.Code == "00")
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
            if(resp?.Code == "1")
                return RedirectToAction("MyCourses", "Course");
            else
            {
                ViewBag.MsjScreen = resp?.Message;
                return View();
            }
        }
    }
}
