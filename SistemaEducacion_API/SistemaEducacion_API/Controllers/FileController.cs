using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion_API.Interfaces;
using SistemaEducacion_API.Models;

namespace SistemaEducacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController(IFileModel _fileModel) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> ListAllBlobs()
        {
            var result = await _fileModel.ListAsync();
            return Ok(result);
        }

        [HttpPost]
        [RequestFormLimits(ValueCountLimit = int.MaxValue, MultipartBodyLengthLimit = long.MaxValue)]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var result = await _fileModel.UploadAsync(file);
            return Ok(result);
        }

        [HttpGet]
        [Route("filename")]
        public async Task<IActionResult> Download(string filename)
        {
            var result = await _fileModel.DownloadAsync(filename);
            return File(result!.Content!, result!.ContentType!, result.Name);
        }

        [HttpDelete]
        [Route("filename")]
        public async Task<IActionResult> Delete(string filename)
        {
            var result = await _fileModel.DeleteAsync(filename);
            return Ok(result);
        }

    }
}
