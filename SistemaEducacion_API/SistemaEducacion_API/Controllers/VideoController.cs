﻿using Azure.Storage.Blobs;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Entities;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController(IConfiguration _configuration) : ControllerBase
    {
        [HttpPost]
        [Route("UploadVideo")]
        public IActionResult UploadVideo(Video entity)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                VideoAnswer answer = new VideoAnswer();

                var result = db.Query<Video>("UploadVideo",
                    new { entity.VideoUrl, entity.MiniPictureUrl, entity.LessonID },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (result != null)
                {
                    answer.Code = "-1";
                    answer.Message = "No se pudo almacenar";
                }
                else
                {
                    answer.Message = "Se insertó exitosamente";
                    answer.Datum = result;
                }
                return Ok(answer);
            }
        }
    }
}

