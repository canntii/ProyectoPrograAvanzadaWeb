using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using SistemaEducacion_API.Entity;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(IConfiguration _config) : ControllerBase
    {
        [HttpPost]
        [Route("AddCourse")]
        public IActionResult AddCourse(Course entity)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                Answer answer = new Answer();
                var result = db.Execute("RegisterCourse", new
                {
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

