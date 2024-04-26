using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using static SistemaEducacion_API.Entities.UserCourse;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssesmentController(IConfiguration _config) : ControllerBase
    {
        [HttpPost]
        [Route("AddAssesment")]
        public IActionResult AddAssesment(Assesment entity)
        {

            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                
                AssesmentAnswer answer = new AssesmentAnswer();

                if(entity.StartDate < DateTime.Now || entity.EndDate < DateTime.Now)
                {
                    answer.Code = "2";
                    answer.Message = "No puedes ingresar una fecha menor a la actual";
                }
                else
                {
                    var result = db.Execute("AddAssesment", new
                    {
                        entity.StartDate,
                        entity.EndDate,
                        entity.MinimumGrade,
                        entity.CourseID
                    }, commandType: CommandType.StoredProcedure);

                    if (result <= 0)
                    {
                        answer.Code = "-1";
                        answer.Message = "Hubo un error";
                    }
                    else
                    {
                        answer.Code = "1";
                        answer.Message = "Matricula con éxito";
                    }
                }
                return Ok(answer);
            }
        }

        [HttpGet]
        [Route("SeeAssesments")]
        public IActionResult SeeAssesments(int CourseID) //VALIDAR QUE CUANDO LA FECHA SEA MENOR AL ENDDATE QUE EL ESTADO PASE A FALSE
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                AssesmentAnswer answer = new AssesmentAnswer();

                var result = db.Query<Assesment>("SeeAssesments",
                    new {CourseID},
                    commandType: CommandType.StoredProcedure).ToList();

                if (result.Count <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No hay exámenes aún...";
                }
                else
                {
                    answer.Data = result;
                }
                return Ok(answer) ;
            }
        }

        [HttpPut]
        [Route("DeleteAssesment")]
        public IActionResult DeleteAssesment(int id)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                AssesmentAnswer answer = new AssesmentAnswer();

                var result = db.Execute("DeleteAssesment",
                    new { id },
                    commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No hay exámenes aún...";
                }
                return Ok(answer);
            }
        }
    }
}
