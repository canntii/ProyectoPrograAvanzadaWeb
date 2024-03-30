using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Services
{
    public interface IVideoModel
    {
        Task<Answer?> UploadVideo(Video entity);
    }
}
