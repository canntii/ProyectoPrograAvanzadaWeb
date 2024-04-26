using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Services
{
    public interface IFileModel
    {
        Task<List<BlobDto>> ListAsync();
        Task<BlobResponseDto> UploadAsync(IFormFile blob);
        Task<BlobDto?> DownloadAsync(string blobFileName);
        Task<BlobResponseDto> DeleteAsync(string blobFileName);
    }
}
