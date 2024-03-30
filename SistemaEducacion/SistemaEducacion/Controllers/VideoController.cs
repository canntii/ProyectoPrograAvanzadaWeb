using Microsoft.AspNetCore.Mvc;
using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Controllers
{
    public class VideoController(IVideoModel _videoModel) : Controller
    {

        [HttpGet]
        public IActionResult UploadVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadVideo(Video entity)
        {
            try
            {
                var result = await _videoModel.UploadVideo(entity);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("La carga del video ha fallado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex} Ocurrió un error interno al procesar la carga del video.");
            }
        }
    }
}
