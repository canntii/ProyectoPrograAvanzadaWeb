using Dapper;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using System.Data;
using System.Data.SqlClient;

namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuscriptionController(IConfiguration _config) : ControllerBase
    {
        [HttpPost]
        [Route("AddSuscription")]
        public IActionResult AddSuscription(Suscription entity)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                Answer answer = new Answer();
                var result = db.Execute("RegisterSuscription", new
                {
                    Type = entity.SuscriptionType,
                    Price = entity.SubscriptionPrice
                }, commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "Ha ocurrido un error que imposibilita registrar la nueva subscripcion..";
                }
                else
                {
                    answer.Code = "1";
                    answer.Message = "Se realizo el registro de la subscripcion correctamente.";
                }
                return Ok(answer);
            }
        }

        [HttpPut]
        [Route("UpdateSubscription")]
        public IActionResult UpdateSuscription(Suscription entity)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                Answer answer = new Answer();
                var result = db.Execute("UpdateSuscription", new
                {
                    Id = entity.SuscriptionID,
                    Type = entity.SuscriptionType,
                    Price = entity.SubscriptionPrice,
                    Estado = entity.Estado
                }, commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "Ha ocurrido un error que imposibilita actualizar la subscripcion..";
                }
                else
                {
                    answer.Code = "1";
                    answer.Message = "Se realizo la actualizacion de la subscripcion correctamente.";
                }
                return Ok(answer);
            }
        }
    }
}