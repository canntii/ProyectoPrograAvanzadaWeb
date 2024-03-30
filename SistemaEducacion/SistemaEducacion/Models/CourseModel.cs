using SistemaEducacion.Entities;
using SistemaEducacion.Services;

namespace SistemaEducacion.Models
{
    public class CourseModel(HttpClient _httpClient, IConfiguration _config) : ICourse
    {
        public Answer AddCourse(Course entity)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Course/AddCourse";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PostAsync(url, body).Result;

            if(resp.IsSuccessStatusCode)
            {
                return resp.Content.ReadFromJsonAsync<Answer>().Result;
            }

            return null;
        }
    }
}
