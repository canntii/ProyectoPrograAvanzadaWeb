using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using static Dapper.SqlMapper;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController(IConfiguration _config) : ControllerBase
    {
        [HttpPost]
        [Route("RegisterLesson")]
        public IActionResult RegisterLesson(Lesson entity)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                Answer answer = new Answer();
                var result = db.Execute("RegisterLesson", new
                {
                    entity.LessonTitle,
                    entity.LessonDescription,
                    entity.CourseID
                }, commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "Ha ocurrido un error que imposibilita registrar la lección..";
                }
                else
                {
                    answer.Code = "1";
                    answer.Message = "Se realizo la inserción de la lección correctamente.";
                }
                return Ok(answer);
            }
        }

        [HttpGet]
        [Route("LessonsPerCourse")]
        public IActionResult LessonsPerCourse(long CourseID)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                LessonAnswer answer = new LessonAnswer();

                var result = db.Query<Lesson>("LessonsPerCourse", new
                { CourseID }, commandType: CommandType.StoredProcedure).ToList();

                if (result == null)
                {
                    answer.Code = "-1";
                    answer.Message = "No existen lecciones asociadas aún";
                }
                else
                {
                    answer.Data = result;
                }

                return Ok(answer) ;
            }
        }

        [HttpPut]
        [Route("UpdateLesson")]
        public IActionResult UpdateLesson(Lesson entity)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                LessonAnswer answer = new LessonAnswer();

                var result = db.Execute("UpdateLesson", new
                { entity.LessonID, entity.LessonTitle, entity.LessonDescription},
                commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No existen lecciones asociadas aún";
                }
                return Ok(answer);
            }
        }

        [HttpPut]
        [Route("DeleteLesson")]
        public IActionResult DeleteLesson(Lesson entity)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                LessonAnswer answer = new LessonAnswer();

                var result = db.Execute("DeleteLesson", new
                { entity.LessonID},
                commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No existen lecciones asociadas para eliminar";
                }
                return Ok(answer);
            }
        }

    }
}
