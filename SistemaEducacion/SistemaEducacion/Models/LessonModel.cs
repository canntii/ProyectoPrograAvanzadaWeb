using SistemaEducacion.Entities;
using SistemaEducacion.Services;

namespace SistemaEducacion.Models
{
    public class LessonModel(IConfiguration _config, HttpClient _httpClient) : ILesson
    {
        public Answer AddLesson(Lesson entity)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Lesson/AddLesson";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
            {
                return resp.Content.ReadFromJsonAsync<Answer>().Result;
            }

            return null;
        }
    }
}
