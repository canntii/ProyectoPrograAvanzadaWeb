using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Models
{
    public class VideoModel(HttpClient _httpClient, IConfiguration _configuration) : IVideoModel
    {
        public VideoAnswer? UploadVideo(Video entity)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Video/UploadVideo";

            entity.VideoUploads = null;
            entity.MiniPictureUploads = null;

            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
            {
                return resp.Content.ReadFromJsonAsync<VideoAnswer>().Result;
            }

            return null;
        }
    }
}
