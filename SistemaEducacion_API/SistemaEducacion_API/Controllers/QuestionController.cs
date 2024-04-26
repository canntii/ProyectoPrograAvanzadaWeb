using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController(IConfiguration _config) : ControllerBase
    {


        [HttpPost]
        [Route("CreateQuestion")]
        public IActionResult CreateQuestion(Question entity)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                Answer answer = new Answer();
                var result = db.Execute("CreateQuestion", new
                {
                    entity.AssesmentID,
                    entity.QuestionDesc,
                    entity.Correct,
                }, commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "Ha ocurrido un error que imposibilita crear la pregunta...";
                }
                else
                {
                    answer.Code = "1";
                    answer.Message = "Se ha registrado la pregunta del curso con éxito..";
                }
                return Ok(answer);
            }
        }

        [HttpGet]
        [Route("SeeQuestionsStudent")]
        public IActionResult SeeQuestionsStudent(int AssesmentID)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                QuestionAnswer answer = new QuestionAnswer();

                var result = db.Query<Question>("SeeQuestionsStudent",
                    new { AssesmentID },
                    commandType: CommandType.StoredProcedure).ToList();

                if (result.Count <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No hay preguntas...";
                }
                else
                {
                    answer.Data = result;
                }
                return Ok(answer);
            }
        }

        [HttpGet]
        [Route("SeeQuestionsTeacher")]
        public IActionResult SeeQuestionsTeacher(int AssesmentID)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                QuestionAnswer answer = new QuestionAnswer();

                var result = db.Query<Question>("SeeQuestionsTeacher",
                    new { AssesmentID },
                    commandType: CommandType.StoredProcedure).ToList();

                if (result.Count <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No hay preguntas...";
                }
                else
                {
                    answer.Data = result;
                }
                return Ok(answer);
            }
        }


        [HttpGet]
        [Route("DeleteQuestion")]
        public IActionResult DeleteQuestion(int AssesmentID)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                QuestionAnswer answer = new QuestionAnswer();

                var result = db.Execute("DeleteQuestion",
                    new { AssesmentID },
                    commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "No hay preguntas...";
                }
                else
                {
                    answer.Code = "-1";
                    answer.Message = "Resultado exitoso";
                }

                return Ok(answer);
            }
        }
    }
}
