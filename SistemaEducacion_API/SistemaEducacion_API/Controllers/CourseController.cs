using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using System.Data;
using System.Data.SqlClient;

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
                    CourseTittle = entity.CourseTittle,
                    CourseDescription = entity.CourseDescription,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate
                }, commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "Ha ocurrido un error que imposibilita registrar el curso...";
                }
                else
                {
                    answer.Code = "1";
                    answer.Message = "Se ha registrado la informacion del curso con exito..";
                }

                return Ok(answer);
            }
        }
    }
}
