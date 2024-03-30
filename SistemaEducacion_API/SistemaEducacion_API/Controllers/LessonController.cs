using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using static Dapper.SqlMapper;
using System.Data.SqlClient;
using System.Data;

namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController(IConfiguration _config) : ControllerBase
    {
        [HttpPost]
        [Route("AddLesson")]
        public IActionResult AddLesson(Lesson entity)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                Answer answer = new Answer();
                var result = db.Execute("RegisterLesson", new
                {
                    LessonTittle = entity.LessonTitle,
                    LessonDescription = entity.LessonDescription,
                    CourseID = entity.CourseID
                }, commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "Ha ocurrido un error que imposibilita registrar la leccion..";
                }
                else
                {
                    answer.Code = "1";
                    answer.Message = "Se realizo la insercion de la leccion correctamente.";
                }
                return Ok(answer);
            }
        }
    }

}
