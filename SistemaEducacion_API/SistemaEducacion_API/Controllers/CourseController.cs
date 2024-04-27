using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using SistemaEducacion_API.Entity;
using SistemaEducacion_API.Services;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(IConfiguration _config, IUtilitariosModel _utilitariosModel) : ControllerBase
    {
        private UserController _userController;

        [HttpPost]
        [Route("AddCourse")]
        public IActionResult AddCourse(Course entity)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                Answer answer = new Answer();
                var result = db.Execute("RegisterCourse", new
                {
                    entity.UserId,
                    entity.CourseTitle,
                    entity.CourseDescription,
                    entity.StartDate,
                    entity.EndDate,
                    entity.PictureUrl
                }, commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "Ha ocurrido un error que imposibilita registrar el curso...";
                }
                else
                {
                    answer.Code = "1";
                    answer.Message = "Se ha registrado la información del curso con éxito..";
                }

                return Ok(answer);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ListCourses")]
        public IActionResult ListCourses()
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                CourseAnswer answer = new CourseAnswer();

                var result = db.Query<Course>("ListCourses"
                    , commandType: CommandType.StoredProcedure).ToList();

                if (result.Count <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No hay cursos...";
                }
                else
                {
                    answer.Data = result;
                }

                return Ok(answer);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("PopularCourses")]
        public IActionResult PopularCourses()
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                CourseAnswer answer = new CourseAnswer();

                var result = db.Query<Course>("PopularCourses"
                    , commandType: CommandType.StoredProcedure).ToList();

                if (result.Count <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No hay cursos...";
                }
                else
                {
                    answer.Data = result;
                    foreach (var item in answer.Data)
                    {
                        var usuario = new UserAnswer();
                        usuario = _utilitariosModel.BuscarUsuario(item.UserId);

                        item.user = usuario.Datum;
                    }
                }

                return Ok(answer);
            }
        }

        [HttpGet]
        [Route("ListMyCourses/{UserId}")]
        public IActionResult ListMyCourses(int UserId)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                CourseAnswer answer = new CourseAnswer();

                var result = db.Query<Course>("ListMyCourses", new {UserId}
                    , commandType: CommandType.StoredProcedure).ToList();

                if (result.Count <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No hay cursos...";
                }
                else
                {
                    answer.Data = result;
                }

                return Ok(answer);
            }
        }

        [HttpGet]
        [Route("ListMySuscriptionCourses/{UserId}")]
        public IActionResult ListMySuscriptionCourses(int UserId)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                CourseAnswer answer = new CourseAnswer();

                var result = db.Query<Course>("ListMySuscriptionCourses", new { UserId }
                    , commandType: CommandType.StoredProcedure).ToList();

                if (result.Count <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No hay cursos...";
                }
                else
                {
                    answer.Data = result;
                }

                return Ok(answer);
            }
        }

        [HttpGet]
        [Route("SeeLessonCourse/{CourseID}")]
        public IActionResult SeeLessonCourse(int CourseID)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                CourseAnswer answer = new CourseAnswer();

                var result = db.Query<Course>("SeeLessonCourse", new { CourseID }
                    , commandType: CommandType.StoredProcedure).ToList();

                if (result.Count <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No hay cursos...";
                }
                else
                {
                    answer.Data = result;
                }

                return Ok(answer);
            }
        }

        [HttpPut]
        [Route("UpdateCourse")]
        public IActionResult UpdateCourse(Course entity)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                CourseAnswer answer = new CourseAnswer();

                var result = db.Execute("UpdateCourse", new
                {
                    entity.CourseID,
                    entity.CourseTitle,
                    entity.CourseDescription,
                    entity.StartDate,
                    entity.EndDate,
                    entity.PictureUrl
                },
                commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "Este curso no existe";
                }
                return Ok(answer);
            }
        }

        [HttpPut]
        [Route("DeleteCourse")]
        public IActionResult DeleteCourse(int CourseID)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                CourseAnswer answer = new CourseAnswer();

                var result = db.Execute("DeleteCourse", new
                { CourseID },
                commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No se puede eliminar, el curso no existe";
                }
                return Ok(answer);
            }
        }


    }
}

