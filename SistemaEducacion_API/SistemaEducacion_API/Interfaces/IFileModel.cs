using SistemaEducacion_API.Entities;

namespace SistemaEducacion_API.Interfaces
{
    public interface IFileModel
    {
        Task<List<BlobDto>> ListAsync();
        Task<BlobResponseDto> UploadAsync(IFormFile blob);
        Task<BlobDto?> DownloadAsync(string blobFileName);
        Task<BlobResponseDto> DeleteAsync(string blobFileName);

    }
}
