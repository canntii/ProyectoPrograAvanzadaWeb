using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using SistemaEducacion_API.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;
using Dapper;
using Microsoft.AspNetCore.Authorization;

namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteoController(IConfiguration _config) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("Conteos")]
        public IActionResult Conteos()
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                Conteos answer = new Conteos();

                var result1 = db.Query<int>("CountStudents"
                    , commandType: CommandType.StoredProcedure).FirstOrDefault();
                answer.Estudiantes = result1;

                var result2 = db.Query<int>("CountProfessors"
                    , commandType: CommandType.StoredProcedure).FirstOrDefault();
                answer.Profesores = result2;

                var result3 = db.Query<int>("CountCourses"
    , commandType: CommandType.StoredProcedure).FirstOrDefault();
                answer.Cursos = result3;

                if(answer != null)
                {
                    return Ok(answer);
                }
                else
                {
                    return BadRequest();
                }

            }
        }
    }
}
