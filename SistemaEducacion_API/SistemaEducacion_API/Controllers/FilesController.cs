using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController(FileService _fileService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> ListAllBlobs()
        {
            var result = await _fileService.ListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var result = await _fileService.UploadAsync(file);
            return Ok(result);
        }

        [HttpGet]
        [Route("filename")]
        public async Task<IActionResult> Download(string filename)
        {
            var result = await _fileService.DownloadAsync(filename);
            return File(result.Content, result.ContentType, result.Name);
        }

        [HttpDelete]
        [Route("filename")]
        public async Task<IActionResult> Delete(string filename)
        {
            var result = await _fileService.DeleteAsync(filename);
            return Ok(result);
        }

    }
}
