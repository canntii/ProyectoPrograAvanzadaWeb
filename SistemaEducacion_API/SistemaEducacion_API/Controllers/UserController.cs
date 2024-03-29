using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using SistemaEducacion_API.Services;
using SistemaEducacion_API.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IConfiguration _configuration, IUtilitariosModel _utilitariosModel,
        IHostEnvironment _hostEnvironment) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")] 
        public IActionResult Login(User entity)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                UserAnswer answer = new UserAnswer();

                var result = db.Query<User>("Login",
                    new { entity.EmailUser, entity.PasswordUser },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (result == null)
                {
                    answer.Code = "-1";
                    answer.Message = "Sus datos no son correctos";
                }
                else
                {
                    answer.Datum = result;
                    answer.Datum.Token = _utilitariosModel.GenerarToken(result.EmailUser ?? string.Empty);
                }

                return Ok(answer);
            }
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser(User entity)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                Answer answer = new Answer();

                var result = db.Execute("RegisterUser",
                    new { entity.FirstNameUser, entity.LastNameUser, entity.EmailUser, entity.PasswordUser},
                    commandType: CommandType.StoredProcedure);

                if(result <= 0)
                {
                    answer.Code = "-1";
                    answer.Message = "Su correo ya se encuentra registrado";
                }
                return Ok(answer);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RecoverAccess")]
        public IActionResult RecoverAccess(User entity)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                UserAnswer answer = new UserAnswer();

                string newPassword = _utilitariosModel.GenerateNewPassword();
                string PasswordUser = _utilitariosModel.Encrypt(newPassword);
                bool Temporary = true;

                var result = db.Query<User>("RecoverAccess",
                    new { entity.EmailUser, PasswordUser, Temporary },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                    
                if(result == null)
                {
                    answer.Code="-1";
                    answer.Message = "Sus datos no son correctos";
                }
                else
                {
                    string route = Path.Combine(_hostEnvironment.ContentRootPath, "Password.html");
                    string htmlBody = System.IO.File.ReadAllText(route);
                    htmlBody = htmlBody.Replace("@User@", result.FirstNameUser);
                    htmlBody = htmlBody.Replace("@UserPassword@", newPassword);

                    _utilitariosModel.SendEmail(result.EmailUser!, "Nueva Clave!!", htmlBody);
                    answer.Datum = result;

                }
                return Ok(answer);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(User entity)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                UserAnswer answer = new UserAnswer(); 
                bool Temporary = false;

                var result = db.Query<User>("ChangePassword",
                    new { entity.EmailUser, entity.PasswordUser, entity.TemporalPassword, Temporary },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if(result == null)
                {
                    answer.Code = "-1";
                    answer.Message = "Sus datos no son correctos";
                }
                else
                {
                    answer.Datum = result;
                }

                return Ok(answer);
            }
        }
  
    }
}
