using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using SistemaEducacion_API.Entity;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;
using static SistemaEducacion_API.Entities.UserCourse;


namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseController(IConfiguration _config) : ControllerBase
    {

        [HttpGet]
        [Route("CourseUser")]
        public IActionResult CourseUser(int UserID)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                UserCourseAnswer answer = new UserCourseAnswer();

            var result = db.Query<UserCourse>("CourseUser", new
                { UserID }, commandType: CommandType.StoredProcedure).ToList();

                if (result.Count <=0)
                {
                    answer.Code = "-1";
                    answer.Message = "No tienes cursos asociados...";
                }
                else
                {
                    answer.Data = result;
                }
                return Ok(answer);
            }
        }

        [HttpPost]
        [Route("EnrollUser")]
        public IActionResult EnrollUser(UserCourse entity)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                UserCourseAnswer answer = new UserCourseAnswer();
                var result = db.Execute("EnrollUser", new
                {
                    entity.UserID,
                    entity.CourseID
                }, commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "Ya estas matriculado";
                }
                else
                {
                    answer.Code = "1";
                    answer.Message = "Matricula con éxito";
                }
                return Ok(answer);
            }
        }
    }
}
