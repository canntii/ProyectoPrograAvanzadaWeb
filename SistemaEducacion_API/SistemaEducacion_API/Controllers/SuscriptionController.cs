using Dapper;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

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
                    entity.SubscriptionType,
                    entity.SubscriptionPrice
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
                    entity.SubscriptionID,
                    entity.SubscriptionType,
                    entity.SubscriptionPrice,
                    entity.Estado
                }, commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "Ha ocurrido un error que imposibilita actualizar la subscripción..";
                }
                else
                {
                    answer.Code = "1";
                    answer.Message = "Se realizo la actualización de la subscripción correctamente.";
                }
                return Ok(answer);
            }
        }

        [HttpDelete]
        [Route("DeleteSuscription")]
        public IActionResult DeleteSubscription(long id)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                Answer answer = new Answer();
                var result = db.Execute("DeleteSuscription", new
                {
                    ID = id
                }, commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "Ha ocurrido un error que imposibilita eliminar la subscripción...";
                }
                else
                {
                    answer.Code = "1";
                    answer.Message = "Se realizo la eliminación de la subscripción correctamente.";
                }
                return Ok(answer);
            }
        }

        [HttpGet]
        [Route("ListSubscriptions")]
        public IActionResult ListSubscriptions()
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                SuscriptionAnswer answer = new SuscriptionAnswer();

                var result = db.Query<Suscription>("ListSuscriptions", commandType: CommandType.StoredProcedure).ToList();

                if (result == null)
                {
                    answer.Code = "-1";
                    answer.Message = "No hay subscripciones insertadas.";
                }
                else
                {
                    answer.Code = "1";
                    answer.Message = "Se han conseguido resultados";
                    answer.data = result;
                }

                return Ok(answer);
            }
        }
    }
}