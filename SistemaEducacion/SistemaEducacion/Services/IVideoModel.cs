using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Services
{
    public interface IVideoModel
    {
        VideoAnswer? UploadVideo(Video entity);
    }
}
