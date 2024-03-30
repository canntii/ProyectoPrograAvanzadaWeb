using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Models
{
    public class VideoModel(HttpClient _httpClient, IConfiguration _configuration) : IVideoModel
    {
        public async Task<Answer?> UploadVideo(Video entity)
        {

            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Video/UploadVideo";

            var formData = new MultipartFormDataContent();

            formData.Add(new StreamContent(entity.VideoUploads!.OpenReadStream()), "VideoUploads", entity.VideoUploads.FileName);
            formData.Add(new StreamContent(entity.MiniPictureUploads!.OpenReadStream()), "PictureUploads", entity.MiniPictureUploads.FileName);
            formData.Add(new StringContent(entity.LessonID.ToString()), "LessonID");

            HttpResponseMessage response = await _httpClient.PostAsync(url, formData);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Answer>();
            }
            else
            {
                return null;
            }
        }
    }

}
