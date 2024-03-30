using SistemaEducacion_API.Entity;

namespace SistemaEducacion_API.Entities
{
    public class Video
    {
        public int VideoID { get; set; }
        public string? VideoUrl { get; set; }
        public string? MiniPictureUrl { get; set; }
        public int LessonID { get; set; }
        public IFormFile? VideoUploads { get; set; }
        public IFormFile? MiniPictureUploads { get; set; }
    }

    public class VideoAnswer
    {
        public VideoAnswer()
        {
            Code = "00";
            Message = string.Empty;
        }

        public string? Code { get; set; }
        public string? Message { get; set; }
        public Video? Datum { get; set; }
        public List<Video>? Data { get; set; }
    }
}
